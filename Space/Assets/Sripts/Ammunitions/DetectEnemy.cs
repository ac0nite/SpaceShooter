using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    [SerializeField] private float _angleDetect = 150f;
    private Collider2D[] _colliders = new Collider2D[10];
    private Vector2 _direction = Vector2.zero;
    void Start()
    {
        _direction = transform.gameObject.GetComponent<MoveBase>().Direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform Detect()
    {
        Array.Clear(_colliders, 0, _colliders.Length);
        var count = Physics2D.OverlapCircleNonAlloc(transform.position, 10f, _colliders, LayerMask.GetMask("Enemy", "Mine"));
        if (count == 0) return null;
      //  if (count == 1) return _colliders[0].transform;
        //Debug.Log($"Count: {count}");
        var list = _colliders.ToList();
        list.RemoveRange(count, list.Count-count);
        list.Sort((a, b) => Vector2.Distance(transform.position, a.transform.position).CompareTo(Vector2.Distance(transform.position, b.transform.position)));
        
        //проверяем где находится объект относительно самого себя - угол относительно направления движения
        foreach (Collider2D col in list)
        {
            //Debug.Log($"a:{Vector2.right} b:{col.transform.position.normalized}  Angle: {Vector2.SignedAngle(Vector2.right, col.transform.position)}");
            var angle = Vector2.SignedAngle(_direction, col.transform.position);
            
            if (transform.position.x < col.transform.position.x && Mathf.Abs(angle) < _angleDetect/2f)
                return col.transform;
        }

       // return list[0].transform;
       return null;
    }
}


