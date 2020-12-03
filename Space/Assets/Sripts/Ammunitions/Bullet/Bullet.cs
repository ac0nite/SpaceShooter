using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : Weapon
{
    [SerializeField] public TypeBullet Type = TypeBullet.Default;
    //[SerializeField] private int _damage = 0;
    //[SerializeField] private GameObject _fxPrefab = null;
    //private Vector3 _pointCollision = Vector3.zero;

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    other.gameObject.GetComponent<HealthComponent>()?.ChangeHealth(-_damage);
    //    _pointCollision = other.contacts[0].point;
    //    Destroy(this.gameObject);
    //}

    //private void OnDestroy()
    //{
    //    if (_pointCollision != Vector3.zero)
    //    {
    //        var fx = Instantiate(_fxPrefab, _pointCollision, Quaternion.identity, GameManager.Instance.transform);
    //        fx.GetComponent<ParticleSystem>().Play();
    //        Destroy(fx, fx.GetComponent<ParticleSystem>().main.duration);
    //    }
    //}

    // public virtual void OnTriggerEnter2D(Collider2D collider)
    // {
    //     var enemyHealth = collider.gameObject.GetComponent<HealthComponent>();
    //     if (enemyHealth != null)
    //     {
    //         enemyHealth.ChangeHealth(-_damage);
    //         if (enemyHealth.Health != 0)
    //             Explosion();
    //         else
    //             Destroy(this.gameObject);
    //     }
    //     else
    //         Explosion();
    // }
    //
    // private void Explosion()
    // {
    //     Debug.Log($"Contact!!!");
    //     GetComponent<MoveBase>().Speed = 0f;
    //     _rebound.Play();
    //     Destroy(this.gameObject,_rebound.main.duration);
    // }
}
