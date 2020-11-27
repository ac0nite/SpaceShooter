using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 10;
    public Action EventDie;
    public int Health { get; private set; }

    void Awake()
    {
        Health = _maxHealth;
    }

    public void Crash()
    {
        ChangeHealth(-Health);
    }
    public void ChangeHealth(int damage)
    {
        Health = Mathf.Clamp(Health + damage, 0, _maxHealth);
        //Debug.Log($"Health: {Health}");
        if (Health == 0)
            EventDie?.Invoke();
    }
}
