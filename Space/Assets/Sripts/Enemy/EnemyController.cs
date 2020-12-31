using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyType Type = EnemyType.Light;
    [SerializeField] private HealthComponent _health = null;
    [SerializeField] private ShootingComponent _shooting = null;
    [SerializeField] private GameObject _explosion = null;
    [SerializeField] private GameObject _model = null;
    private bool _isRemove = false;
    private void Awake()
    {

    }

    void Start()
    {
        InvokeRepeating("Fire", 1f, 2f);
    }

    private void Fire()
    {
        //Shooting.FireBullet(Vector2.left);
        _shooting.Fire(TypeAmmunition.Bullet, Vector2.left, true);
    }

    void Update()
    {
        if (_health.Health == 0)
            Destroy(this.gameObject);

        //if (_health.Health == 0)
        //{
        //    if (_explosion != null)
        //    {
        //        if(!_isRemove)
        //            StartCoroutine(DestroyShip());
        //    }
        //    else
        //    {
        //        Destroy(this.gameObject);
        //    }
        //}
    }

    //IEnumerator DestroyShip()
    //{
    //    _isRemove = true;
        
    //    _explosion.Play();
    //    yield return null;
    //    yield return null;
    //    _model.SetActive(false);
    //    Destroy(this.gameObject, t: _explosion.main.duration);
    //}

    private void OnDestroy()
    {
        if (_health.Health == 0)
        {
            _model.SetActive(false);
            var fx = Instantiate(_explosion, transform.position, Quaternion.identity, GameManager.Instance.transform);
            fx.GetComponent<ParticleSystem>().Play();
            Instantiate(GameManager.Instance.Bonus[3], transform.position, Quaternion.identity, GameManager.Instance.transform);
            Destroy(fx, fx.GetComponent<ParticleSystem>().main.duration);
            
        }
    }
}
