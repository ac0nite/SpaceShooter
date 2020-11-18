using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionEnemyMine : MonoBehaviour
{
    [SerializeField] private MoveBase _move = null;
    [SerializeField] private int _damage = 0;
    [SerializeField] private float _distanceToActive = 0.5f;
    [SerializeField] private float _distanceToAttack = 2f;
    [SerializeField] private float _acceleration = 1.5f;
    private GameObject _ship = null;
    private float distance = 0f;

    void Update()
    {
        if (_ship != null)
        {
            if (Vector2.Distance(_ship.transform.position, transform.position) <= _distanceToActive)
            {
                _ship.GetComponent<HealthComponent>()?.ChangeHealth(-_damage);
                Destroy(this.gameObject);
            }
            else
            {
                _move.Direction = (_ship.transform.position - transform.position).normalized;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        _ship = collider.gameObject;
        _move.Speed *= _acceleration;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        _ship = null;
        _move.Direction = Vector2.left; 
        _move.Speed /= _acceleration;

    }
}
