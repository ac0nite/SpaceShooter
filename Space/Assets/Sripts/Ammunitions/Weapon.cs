using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Vector3 _pointExplosion = Vector3.zero;
    [SerializeField] private GameObject _fx_prefab = null;
    [SerializeField] private int _damage = 1;
    public virtual void OnDestroy()
    {
        if (_pointExplosion != Vector3.zero && _fx_prefab != null)
        {
            var fx = Instantiate(_fx_prefab, _pointExplosion, Quaternion.identity, GameManager.Instance.transform);
            fx.GetComponent<ParticleSystem>().Play();
            Destroy(fx, fx.GetComponent<ParticleSystem>().main.duration);
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {
        _pointExplosion = other.contacts[0].point;
        other.gameObject.GetComponent<HealthComponent>()?.ChangeHealth(-_damage);
        Destroy(this.gameObject);
    }
}
