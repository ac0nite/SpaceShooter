using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    [SerializeField] private float _speed = 1f;
    private Vector3 scope = Vector3.zero;
    [SerializeField] private HealthComponent _health = null;
    [SerializeField] private ShootingComponent _shooting = null;
    [SerializeField] private Pickup _pickup = null;

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
       //_shooting.FireBullet(Vector2.right);
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
    public void FireBullet(bool isFire)
    {
        _shooting.Fire(TypeAmmunition.Bullet, Vector2.right, isFire);
    }

    public void FireHardBullets(bool isFire)
    {
        _shooting.Fire(TypeAmmunition.HardBullet, Vector2.right, isFire);
    }

    public void FireRocket(bool isFire)
    {
        _shooting.Fire(TypeAmmunition.Rocket, Vector2.right, isFire);
    }

    private void Crash(GameObject other)
    {
        other.GetComponent<HealthComponent>()?.Crash();
        //TODO: реализовать механизм уничтожения player
    }

    private void AddingResource(GameObject other)
    {
        Debug.Log($"AddingResource");
        Destroy(other);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"Player OnTriggerEnter: {other.gameObject.layer} {LayerMask.NameToLayer()}");
        if(other.gameObject.layer == LayerMask.NameToLayer("Ammunition"))
            _pickup.PickupAmunitions(other.gameObject);
        else if(other.gameObject.layer == LayerMask.NameToLayer("Enemy") || 
                other.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
            Crash(other.gameObject);
        else if(other.gameObject.layer == LayerMask.NameToLayer("Bonus"))
            AddingResource(other.gameObject);
    }
}
