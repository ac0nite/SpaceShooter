using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AmmunitionBase
{
    [SerializeField] protected int _damage = 2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("OnTriggerEnter2D BULLET", collider.gameObject);
        Destroy(this.gameObject);
        collider.gameObject.GetComponent<HealthComponent>().ChangeHealth(-1);
    }
}
