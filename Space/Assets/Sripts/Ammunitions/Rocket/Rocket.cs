using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Weapon
{
    //[SerializeField] private HealthComponent _health = null;
    
    [SerializeField] private float _acceleration = 2f;

    [SerializeField] private float _timeStartDelayDetect = 1f;
    private DetectEnemy _detect = null;
    private MoveBase _move = null;
    private float _speed = 0;
   // [SerializeField] private int _damage = 0;

    private Transform _enemy = null;
    private bool _isDetect = false;
    void Start()
    {
        _move = GetComponent<MoveBase>();
        _speed = _move.Speed;

        _detect = GetComponent<DetectEnemy>();

        StartCoroutine(AttackEnemy());
    }

    public Quaternion LookAt2D(Vector3 current, Vector3 target)
    {
        Vector3 direction = target - current;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Update()
    {
        //if (_health.Health == 0)
        //{
        //    Destroy(this.gameObject);
        //}

        if (!_isDetect) return;

        if (_enemy == null)
        {
            Detect();
            return;
        }

        //if (Vector2.Distance(transform.position, _enemy.position) <= 0.2f)
        //{
        //    _enemy.GetComponent<HealthComponent>().ChangeHealth(-_damage);
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //   // _move.Direction = (tr.position - transform.position).normalized;
        //    transform.rotation = Quaternion.Slerp(transform.rotation, LookAt2D(transform.position, _enemy.position), Time.deltaTime * 5f);
        //}
        transform.rotation = Quaternion.Slerp(transform.rotation, LookAt2D(transform.position, _enemy.position), Time.deltaTime * 5f);
    }

    IEnumerator AttackEnemy()
    {
        yield return new WaitForSeconds(_timeStartDelayDetect);
        _isDetect = true;
        Detect();
    }

    private void Detect()
    {
        _enemy = _detect.Detect(LayerMask.GetMask("Enemy", "Mine"));

        if (_enemy != null) 
            _move.Speed = Mathf.Clamp(_move.Speed * _acceleration, _speed, _speed * _acceleration);
    }
}
