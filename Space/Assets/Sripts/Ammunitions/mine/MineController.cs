using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    [SerializeField] private HealthComponent _health = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_health.Health == 0)
        {
            Destroy(this.gameObject);
        }

        //if (_ship != null)
        //{
        //    if (Vector2.Distance(_ship.transform.position, transform.position) <= _distanceToActive)
        //    {
        //        Destroy(this.gameObject);
        //        _ship.GetComponent<HealthComponent>().ChangeHealth(-_damage);
        //    }
        //    else
        //    {
        //        _move.Direction = (_ship.transform.position - transform.position).normalized;
        //    }
        //}

        //distance = Vector2.Distance(GameManager.Instance.Player.transform.position, transform.position);
        //if (distance <= _distanceToActive)
        //{
        //    Destroy(this.gameObject);
        //    GameManager.Instance.Player.GetComponent<HealthComponent>().ChangeHealth(-_damage);
        //}
        //else if(distance <= _distanceToAttack)
        //{
        //    _move.Direction = (GameManager.Instance.Player.transform.position - transform.position).normalized;
        //}
        //else
        //{
        //    _move.Direction = Vector2.left;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log($"mine enter trigger");
        //Debug.Log($"Mine {collider.gameObject.layer.ToString()}");
        //Debug.Log($"mine enter trigger");
        //_ship = collider.gameObject;
        // _move.Speed *= 1.2f;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        //_ship = null;
        //_move.Direction = Vector2.left;
        //// _move.Speed /= 1.2f;

        //Debug.Log($"mine exit trigger");
    }
}
