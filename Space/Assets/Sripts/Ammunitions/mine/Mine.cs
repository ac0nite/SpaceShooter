using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private HealthComponent _health = null;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (_health.Health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
