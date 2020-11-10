using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDetectEnemy : MonoBehaviour
{

    private Collider2D[] _colliders = new Collider2D[3];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Detect()
    {
        Physics2D.OverlapCircleNonAlloc(transform.position, 7f, _colliders, LayerMask.GetMask("Enemy"));
    }
}
