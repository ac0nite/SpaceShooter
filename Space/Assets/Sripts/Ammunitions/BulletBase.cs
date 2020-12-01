using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField] protected int _damage = 0;
    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(this.gameObject);
        collider.gameObject.GetComponent<HealthComponent>()?.ChangeHealth(-_damage);
    }
}
