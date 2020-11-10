using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionEnemy : MonoBehaviour
{
    [SerializeField] private MoveBase _move = null;
    [SerializeField] private int _damage = 0;
    [SerializeField] private float _distanceToActive = 0.5f;
    [SerializeField] private float _distanceToAttack = 2f;
    private GameObject _ship = null;
    private float distance = 0f;

    // Update is called once per frame
    void Update()
    {
        //distance = Vector2.Distance(GameManager.Instance.Player.transform.position, transform.position);
        //if (distance <= _distanceToActive)
        //{
        //    Destroy(this.gameObject);
        //    GameManager.Instance.Player.GetComponent<HealthComponent>().ChangeHealth(-_damage);
        //}
        //else if (distance <= _distanceToAttack)
        //{
        //    _move.Direction = (GameManager.Instance.Player.transform.position - transform.position).normalized;
        //    _move.Speed = _move.Speed * 1.01f;
        //}
        //else
        //{
        //    _move.Direction = Vector2.left;
        //    //_move.Speed /= 1.2f;
        //}

        if (_ship != null)
        {
            if (Vector2.Distance(_ship.transform.position, transform.position) <= _distanceToActive)
            {
                _ship.GetComponent<HealthComponent>().ChangeHealth(-_damage);
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
        
        //Debug.Log($"enter Mine {collider.gameObject.layer.ToString()}");
        
        _ship = collider.gameObject;
        _move.Speed *= 1.5f;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        //Debug.Log($"exit Mine {collider.gameObject.layer.ToString()}");
        _ship = null;
        _move.Direction = Vector2.left; 
        _move.Speed /= 1.5f;

    }
}
