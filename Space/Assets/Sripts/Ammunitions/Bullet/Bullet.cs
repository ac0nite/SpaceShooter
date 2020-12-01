using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public TypeBullet Type = TypeBullet.Default;
    [SerializeField] private int _damage = 0;
    [SerializeField] private GameObject _fxPrefab = null;
    private Vector3 _contact = Vector3.zero;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        collision.gameObject.GetComponent<HealthComponent>()?.ChangeHealth(-_damage);
        _contact = collision.contacts[0].point;
        Debug.Log($"{collision.contactCount}");
    }

    private void OnDestroy()
    {
        if (_contact != Vector3.zero)
        {
            var fx = Instantiate(_fxPrefab, _contact, Quaternion.identity, GameManager.Instance.transform);
            fx.GetComponent<ParticleSystem>().Play();
            Destroy(fx, fx.GetComponent<ParticleSystem>().main.duration);
        }
    }

    //public void OnTriggerEnter2D(Collider2D collider)
    //{
    //    Destroy(this.gameObject);
    //    collider.gameObject.GetComponent<HealthComponent>()?.ChangeHealth(-_damage);
    //}
}
