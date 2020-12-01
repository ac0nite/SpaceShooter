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
    [SerializeField] private bool _rotate = false;
    [SerializeField] [Range(1f, 40f)] private float _speedRotate = 1f;
    private float _speed = 0f;
    private Rigidbody2D _rg = null;

    public Vector2 Direction { set; get; }
    public float Speed { set; get; }

    void Awake()
    {
        if (isRandomSpeed) Speed  = _speed = Random.Range(0.5f, _maxSpeed);
        else Speed  = _speed = _maxSpeed;
        Direction = _direction;
        _rg = GetComponentInChildren<Rigidbody2D>();
    }
    void Update()
    {
        _speed = Mathf.Lerp(_speed, Speed, Time.deltaTime * 5f);
        
        transform.Translate(Direction * _speed * Time.deltaTime);
        //transform.Rotate();
        if (_isDeleteObjectScope)
        {
            if(transform.position.x <= -GameManager.Instance.GenerateTransform.position.x ||
               transform.position.x >= GameManager.Instance.GenerateTransform.position.x + 0.1f)
                Destroy(this.gameObject);
        }

        if (_rotate) 
            //transform.Rotate(Vector3.forward, _speedRotate * Time.deltaTime);
            _rg.transform.Rotate(Vector3.forward, _speedRotate * Time.deltaTime);
    }
    
    //rotate
//     transform.Rotate(Vector3(0, 0, 50));
// //instead of :
//     transform.eulerAngles = new Vector3 (0, 0, 50);
// //or like you said
//     transform.eulerAngles = Vector3.forward * 50;
}
