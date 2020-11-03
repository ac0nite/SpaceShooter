using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{

    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Vector2 _direction = Vector2.left;
    [SerializeField] private float _speedRotation = 0.0f;
    
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
        //transform.Rotate();
    }
}
