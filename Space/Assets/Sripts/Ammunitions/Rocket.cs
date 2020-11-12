using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private HealthComponent _health = null;
    [SerializeField] private MoveBase _move = null;
    [SerializeField] private RocketDetectEnemy _detect = null;

    [SerializeField] private float _timeStartDelayDetect = 1f;
    [SerializeField] private int _damage = 0;

    private Transform _enemy = null;
    private bool _isDetect = false;
    void Start()
    {
        StartCoroutine(AttackEnemy());

        //tr = GetComponent<RocketDetectEnemy>().Detect();
        //_move.Speed *= 1.8f;

        //transform.LookAt(Vector3.forward, Vector3.Cross(Vector3.forward, tr.position - transform.position));
        // var rotation = Quaternion.LookRotation(tr.position - transform.position);
        // transform.rotation = rotation;
        /*  Vector3 direction = (currDest - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            */

        // Vector3 direction = tr.position - transform.position;
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // Quaternion lookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // transform.rotation = lookRotation;
    }

    public Quaternion LookAt2D(Vector3 current, Vector3 target)
    {
        Vector3 direction = target - current;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Update()
    {
        if (_health.Health == 0)
        {
            Destroy(this.gameObject);
        }

        if (!_isDetect) return;

        if (_enemy == null)
        {
            
            _enemy = _detect.Detect();
            if(_enemy != null) _move.Speed *= 1.5f;
            return;
        }

        if (Vector2.Distance(transform.position, _enemy.position) <= 0.2f)
        {
            _enemy.GetComponent<HealthComponent>().ChangeHealth(-_damage);
            Destroy(this.gameObject);
        }
        else
        {
           // _move.Direction = (tr.position - transform.position).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, LookAt2D(transform.position, _enemy.position), Time.deltaTime * 5f);
        }
    }

    IEnumerator AttackEnemy()
    {
        yield return new WaitForSeconds(_timeStartDelayDetect);
        _isDetect = true;
        _enemy = _detect.Detect();
    }
}
