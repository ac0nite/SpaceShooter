using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class RocketDetectEnemy : MonoBehaviour
{

    private Collider2D[] _colliders = new Collider2D[10];
    // Start is called before the first frame update
    void Start()
    {
        //Detect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform Detect()
    {
        Array.Clear(_colliders, 0, _colliders.Length);
        var count = Physics2D.OverlapCircleNonAlloc(transform.position, 10f, _colliders, LayerMask.GetMask("Enemy"));
        //Debug.Log($"Count: {count}");
        var list = _colliders.ToList();
        list.RemoveRange(count, list.Count-count);
        list.Sort((a, b) => Vector2.Distance(transform.position, a.transform.position).CompareTo(Vector2.Distance(transform.position, b.transform.position)));
        return list[0].transform;
    }
}
