using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    enum ScopeMonitoring
    {
        InFront = 0,
        Behind = 1,
        All = 3
    }

    [SerializeField] private float _angle = 150f;
    [SerializeField] private float _radius = 10f;
    private Collider2D[] _colliders = new Collider2D[10];
    private Vector2 _direction = Vector2.zero;
    [SerializeField] private ScopeMonitoring _scopeMonitoring = ScopeMonitoring.All;
    private int _hashCodeObjectDetect = 0;
    void Start()
    {
        _direction = transform.gameObject.GetComponent<MoveBase>().Direction;
    }
    

    public Transform Detect(int layerMask)
    {
        Array.Clear(_colliders, 0, _colliders.Length);
        var count = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _colliders, layerMask);
        if (count == 0) return null;

        var list = _colliders.ToList();
        list.RemoveRange(count, list.Count-count);
        list.Sort((a, b) => Vector2.Distance(transform.position, a.transform.position).CompareTo(Vector2.Distance(transform.position, b.transform.position)));
        
        //проверяем где находится объект относительно самого себя - угол относительно направления движения
        foreach (Collider2D col in list)
        {
            var angle = Vector2.SignedAngle(_direction, col.transform.position);
            if (_scopeMonitoring == ScopeMonitoring.InFront)
            {
                if (transform.position.x < col.transform.position.x && Mathf.Abs(angle) < _angle/2f)
                    return col.transform;   
            }
            else if (_scopeMonitoring == ScopeMonitoring.Behind)
            {
                if (transform.position.x > col.transform.position.x && Mathf.Abs(angle) < _angle/2f)
                    return col.transform;
            }
            else
            {
                //if(_scopeMonitoring == ScopeMonitoring.All)
                return col.transform;
            }
        }
        
        return null;
    }
}