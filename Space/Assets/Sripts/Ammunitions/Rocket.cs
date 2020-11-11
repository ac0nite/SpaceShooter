using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private int _damage = 0;
    [SerializeField] private HealthComponent _health = null;
    [SerializeField] private float _timeSearchEnemy = 1f;
    [SerializeField] private MoveBase _move = null;
    private Transform tr = null;
    void Start()
    {
        //StartCoroutine(AttackEnemy());
        tr = GetComponent<RocketDetectEnemy>().Detect();
        _move.Speed *= 1.8f;
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
        if(tr == null) return;

        if (Vector2.Distance(transform.position, tr.position) <= 0.2f)
        {
            tr.GetComponent<HealthComponent>().ChangeHealth(-_damage);
            Destroy(this.gameObject);
        }
        else
        {
            _move.Direction = (tr.position - transform.position).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, LookAt2D(transform.position, tr.position), Time.deltaTime * 10f);
        }
    }

    IEnumerator AttackEnemy()
    {

        yield return new WaitForSeconds(_timeSearchEnemy);

    }
}
