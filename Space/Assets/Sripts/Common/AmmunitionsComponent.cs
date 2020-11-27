using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class AmmunitionsComponent : MonoBehaviour
{
    [SerializeField] public int CountRockets = 10;
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"BONUS");
        if (other.gameObject.layer == LayerMask.NameToLayer("Bonus"))
        {
            var bonus = other.GetComponent<Bonus>();
            switch (bonus.Type)
            {
                case TypeAmmunition.Rocket:
                    CountRockets += bonus.Count;
                    break;
                case TypeAmmunition.Life:
                    GameManager.Instance.LIFE += bonus.Count;
                    break;
                default:
          //          Debug.Log("Тип не определён");
                    break;
            }
        }
    }
}
