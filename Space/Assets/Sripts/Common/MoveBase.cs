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
    

    public Vector2 Direction { set; get; }
    public float Speed { set; get; }

    void Awake()
    {
        if (isRandomSpeed) Speed = Random.Range(0.5f, _maxSpeed);
        else Speed = _maxSpeed;
        Direction = _direction;
    }
    void Update()
    {
        //Debug.Log($"Direction {Direction}");
        transform.Translate(Direction * Speed * Time.deltaTime);
        //transform.Rotate();
        if (_isDeleteObjectScope)
        {
            if(transform.position.x <= -GameManager.Instance.GenerateTransform.position.x ||
               transform.position.x >= GameManager.Instance.GenerateTransform.position.x + 0.1f)
                Destroy(this.gameObject);
        }
    }
}
