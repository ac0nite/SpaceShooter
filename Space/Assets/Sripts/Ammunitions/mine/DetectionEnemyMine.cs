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
    [SerializeField] private ParticleSystem _explosion = null;
    private bool _isDestroy = false;
    [SerializeField] private GameObject _model = null;
    private GameObject _ship = null;
    private float distance = 0f;

    void Update()
    {
        if (_ship != null)
        {
            if (!_isDestroy  && Vector2.Distance(_ship.transform.position, transform.position) <= _distanceToActive)
            {
                _isDestroy = true;
                //_move.Speed = 0f;
                _model.SetActive(false);
                _ship.GetComponent<HealthComponent>()?.ChangeHealth(-_damage);
                _explosion.Play();
                Destroy(this.gameObject, _explosion.main.duration);
            }
            else
            {
                _move.Direction = (_ship.transform.position - transform.position).normalized;
            }
        }
    }

    // private void OnTriggerEnter2D(Collider2D collider)
    // {
    //     Debug.Log($"Mines OnTriggerEnter2D");
    //     _ship = collider.gameObject;
    //     _move.Speed *= _acceleration;
    // }
    //
    // private void OnTriggerExit2D(Collider2D collider)
    // {
    //     Debug.Log($"Mines OnTriggerExit2D");
    //
    //     _ship = null;
    //     _move.Direction = Vector2.left; 
    //     _move.Speed /= _acceleration;
    // }

    void LateUpdate()
    {
        
    }
}
