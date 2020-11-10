using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _damage = 0f;
    [SerializeField] private HealthComponent _health = null;
    [SerializeField] private float _timeSearchEnemy = 1f;

    void Start()
    {
        StartCoroutine(AttackEnemy());
    }

    void Update()
    {
        if (_health.Health == 0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator AttackEnemy()
    {

        yield return new WaitForSeconds(_timeSearchEnemy);

    }
}
