using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveBase : MonoBehaviour
{
    [SerializeField] private bool isRandomSpeed = true;
    [SerializeField] private float _maxSpeed = 2.0f;
    [SerializeField] private Vector2 _direction = Vector2.left;
    [SerializeField] private float _speedRotation = 0.0f;
    [SerializeField] private bool _isDeleteObjectScope = false;
    private float _speed = 0f;

    public Vector2 Direction { set; get; }

    public void dir(Vector2 dir)
    {
        Direction = dir;
    }

    void Awake()
    {
        if (isRandomSpeed) _speed = Random.Range(0.5f, _maxSpeed);
        else _speed = _maxSpeed;
        Direction = _direction;
        //GetComponent<SpriteRenderer>().color = 
    }
    void Update()
    {
        Debug.Log($"Direction {Direction}");
        transform.Translate(Direction * _speed * Time.deltaTime);
        //transform.Rotate();
        if (_isDeleteObjectScope)
        {
            if(transform.position.x <= -GameManager.Instance.GenerateTransform.position.x)
                Destroy(this.gameObject);
        }
    }
}
