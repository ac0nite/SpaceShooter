using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    [SerializeField] private float _speed = 1f;
    private Vector3 scope = Vector3.zero;
    [SerializeField] private HealthComponent _health = null;
    [SerializeField] private ShootingComponent _shooting = null;

    void Start()
    {
        scope = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        //InvokeRepeating("Fire", 0.5f, 0.4f);
        
    }

    void Update()
    {
       transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -scope.x, +scope.x),
            Mathf.Clamp(transform.position.y, -scope.y, +scope.y));


       //_shooting.FireRockets(Vector2.right);
       _shooting.FireBullet(Vector2.right);
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    void OnBecameVisible()
    {
        //Debug.Log($"OnBecameVisible: {Camera.main.ScreenToViewportPoint(transform.position)}");
    }

    void OnBecameInvisible()
    {
        //Debug.Log($"OnBecameInvisible: {Camera.main.ScreenToViewportPoint(transform.position)}");
    }

    //DEBUG
    public void Fire()
    {
        _shooting.FireBullet(Vector2.right);
    }
}
