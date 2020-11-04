using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private HealthComponent _health = null;
    [SerializeField] private ShootingComponent _shooting = null;

    private void Awake()
    {

    }

    void Start()
    {
        InvokeRepeating("Fire", 1f, 2f);
    }

    private void Fire()
    {
        _shooting.FireBullet(Vector2.left);
    }

    void Update()
    {
        
    }
}
