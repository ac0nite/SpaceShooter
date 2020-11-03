using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveBase : MonoBehaviour
{

    [SerializeField] private float _maxSpeed = 2.0f;
    [SerializeField] private Vector2 _direction = Vector2.left;
    [SerializeField] private float _speedRotation = 0.0f;
    [SerializeField] private bool _isDeleteObjectScope = false;
    private float _speed = 0f;
    void Start()
    {
        _speed = Random.Range(0.5f, _maxSpeed);
        //GetComponent<SpriteRenderer>().color = 
    }
    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
        //transform.Rotate();
        if (_isDeleteObjectScope)
        {
            if(transform.position.x <= -GameManager.Instance.GenerateTransform.position.x)
                Destroy(this.gameObject);
        }
    }
}
