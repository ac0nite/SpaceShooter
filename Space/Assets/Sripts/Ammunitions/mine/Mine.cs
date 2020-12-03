using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Weapon
{
   // [SerializeField] private GameObject _fx = null;
   // [SerializeField] private GameObject _model = null;
    //[SerializeField] private HealthComponent _health = null;
    //[SerializeField] private int _damage = 4;
    [SerializeField] private float _acceleration = 3f;
    private DetectEnemy _detect = null;
    private MoveBase _move = null;
    private Transform _enemy = null;
    private float _speed = 0f;
   // private Vector2 _pointCollision = Vector2.zero;

    private void Awake()
    {
        _detect = GetComponent<DetectEnemy>();
        _move = GetComponent<MoveBase>();
     //   _health.EventDie += OnDie;
    }

    private void Start()
    {
        _speed = _move.Speed;
    }

    //private void OnDestroy()
    //{
    //   // _health.EventDie -= OnDie;
    //   if (_pointCollision != Vector2.zero)
    //   {
    //       //GetComponent<Collider2D>().enabled = false;
    //       //_model.SetActive(false);
    //       var fx = Instantiate(_fx, _pointCollision, Quaternion.identity, GameManager.Instance.transform);
    //       fx.GetComponent<ParticleSystem>().Play();
    //       Destroy(fx, fx.GetComponent<ParticleSystem>().main.duration);
    //   }
    //}

    private void OnDie()
    {
        //GetComponent<Collider2D>().enabled = false;
        //_model.SetActive(false);
        //_explosion.Play();
        //Destroy(this.gameObject, _explosion.main.duration);
    }

    void Update()
    {
        if (Detect())
        {
            _move.Direction = (_enemy.position - transform.position).normalized;
        }
    }

    private bool Detect()
    {
        _enemy = _detect.Detect(LayerMask.GetMask("Player"));
        if (_enemy == null)
        {
            _move.Direction = Vector2.left;
            _move.Speed = Mathf.Clamp(_move.Speed / _acceleration, _speed / _acceleration, _speed);
            return false;
        }
        else
        {
            _move.Speed = Mathf.Clamp(_move.Speed * _acceleration, _speed , _speed * _acceleration);
        }

        return true;
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    _pointCollision = other.contacts[0].point;
    //    other.gameObject.GetComponent<HealthComponent>()?.ChangeHealth(-_damage);
    //    Destroy(other.gameObject);
    //}

    // private void OnTriggerEnter2D(Collider2D collider)
    // {
    //     var enemyHealth = collider.gameObject.GetComponent<HealthComponent>();
    //     if (enemyHealth != null)
    //     {
    //         collider.gameObject.GetComponent<HealthComponent>()?.ChangeHealth(-_damage);
    //         OnDie();
    //     }
    // }
}
