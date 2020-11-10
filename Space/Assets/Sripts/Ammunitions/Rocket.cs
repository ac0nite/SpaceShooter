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
        }
    }

    IEnumerator AttackEnemy()
    {

        yield return new WaitForSeconds(_timeSearchEnemy);

    }
}
