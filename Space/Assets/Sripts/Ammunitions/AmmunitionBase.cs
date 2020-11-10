using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionBase : MonoBehaviour
{
    [SerializeField] protected TypeAmmunition Type = TypeAmmunition.Undefined;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(this.gameObject);
        Trigger(collider);
    }

    protected virtual void Trigger(Collider2D collider)
    {

    }
}
