using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShipController : MonoBehaviour
{

    [SerializeField] private float _speed = 1f;
    private Vector3 scope = Vector3.zero;
    [SerializeField] public HealthComponent Health = null;
    [SerializeField] public ShootingComponent Shooting = null;
    [SerializeField] public AmmunitionsComponent Ammunitions = null;
    [SerializeField] private AudioSource _audioSourcePickup = null;

    void Start()
    {
        scope = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        Ammunitions = GetComponent<AmmunitionsComponent>();
    }

    void Update()
    {
       transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, -scope.x, +scope.x),
            Mathf.Clamp(transform.position.y, -scope.y, +scope.y));


       //Shooting.FireRockets(Vector2.right);
       //Shooting.FireBullet(Vector2.right);
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
        Shooting.Fire(TypeAmmunition.Bullet, Vector2.right, isFire);
    }

    public void FireHardBullets(bool isFire)
    {
        Shooting.Fire(TypeAmmunition.HardBullet, Vector2.right, isFire);
    }

    public void FireRocket(bool isFire)
    {
        Shooting.Fire(TypeAmmunition.Rocket, Vector2.right, isFire);
    }

    private void Crash(GameObject other)
    {
        other.GetComponent<HealthComponent>()?.Crash();
        //TODO: реализовать механизм уничтожения player
    }

    private void AddingResource(GameObject other)
    {
        _audioSourcePickup.pitch = Random.Range(0.8f, 1.2f);
        _audioSourcePickup.Play();

        Debug.Log($"AddingResource");
        var bonus = other.GetComponent<Bonus>();
        switch (bonus.Type)
        {
            case TypeAmmunition.Life:
                GameManager.Instance.LIFE += bonus.Count;
                break;
            case TypeAmmunition.Rocket:
                Ammunitions.CountRockets += bonus.Count;
                break;
            case TypeAmmunition.Health:
                Health.ChangeHealth(+bonus.Count);
                break;
        }
        Destroy(other);
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log($"Player OnTriggerEnter: {other.gameObject.layer} {LayerMask.NameToLayer()}");
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy") || 
                other.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
            Crash(other.gameObject);
        else if(other.gameObject.layer == LayerMask.NameToLayer("Bonus"))
            AddingResource(other.gameObject);
    }
}
