using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyType Type = EnemyType.Light;
    [SerializeField] private HealthComponent _health = null;
    [SerializeField] private ShootingComponent _shooting = null;
    [SerializeField] private ParticleSystem _explosion = null;
    [SerializeField] private GameObject _model = null;

    private void Awake()
    {

    }

    void Start()
    {
        InvokeRepeating("Fire", 1f, 2f);
    }

    private void Fire()
    {
        //_shooting.FireBullet(Vector2.left);
        _shooting.Fire(TypeAmmunition.Bullet, Vector2.left, true);
    }

    void Update()
    {
        if (_health.Health == 0)
        {
            if (_explosion != null)
            {
                // this.enabled = false;
                _model.SetActive(false);
                _explosion.Play();
                Destroy(this.gameObject, t: 1f);
            }
            else
            {
                Destroy(this.gameObject);
            }
            
            //Debug.Log($"Enemy die!", this.gameObject);
        }
    }
}
