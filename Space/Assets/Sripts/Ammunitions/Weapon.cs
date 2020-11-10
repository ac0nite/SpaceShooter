using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : AmmunitionBase
{
    [SerializeField] protected int _damage = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Trigger(Collider2D collider)
    {
        collider.gameObject.GetComponent<HealthComponent>()?.ChangeHealth(-_damage);
    }
}
