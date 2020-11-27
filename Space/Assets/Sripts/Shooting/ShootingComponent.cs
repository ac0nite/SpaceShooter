using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    [SerializeField] private Transform _shootingPointBullet = null;
    [SerializeField] private List<Transform> _shootingPointsHardBullet = null;
    [SerializeField] private Transform _shootingPointRocket = null;
    [SerializeField] private float _bulletDelayShooting = 0.2f;
    [SerializeField] private float _hardBulletDelayShooting = 0.3f;
    [SerializeField] private float _rocketDelayShooting = 0.5f;
    [SerializeField] private AmmunitionsComponent _ammunitions = null;
    private Vector2 _direction = Vector2.right;
    
    [SerializeField] public TypeBullet CurrentBullet = TypeBullet.Default;
    [SerializeField] public TypeHardBullet CurrentHardBullet = TypeHardBullet.Default;

    private bool isFireBullet = false;
    private bool isFireHardBullet = false;
    private bool isFireRocket = false;

    private bool isReadyFire = true;

    void Update()
    {
        if (isFireBullet) FireBullet(_direction);
        if (isFireHardBullet) FireHardBullets(_direction);
        if (isFireRocket) FireRocket(_direction);
    }

    public void Fire(TypeAmmunition type, Vector2 direction, bool isPressFire)
    {
        //Debug.Log($"isPressFire: {isPressFire}");
        _direction = direction;
        if (type == TypeAmmunition.Bullet) isFireBullet = isPressFire;
        else if (type == TypeAmmunition.HardBullet) isFireHardBullet = isPressFire;
        else if (type == TypeAmmunition.Rocket) isFireRocket = isPressFire;
    }

    private void FireBullet(Vector2 direction)
    {
        if (!isReadyFire) return;
        isReadyFire = false;
        var bullet = Instantiate(GameManager.Instance.Bullets[GameManager.Instance.Bullets.FindIndex(0, b => b.Type == CurrentBullet)], _shootingPointBullet.position, Quaternion.identity);
        bullet.GetComponent<MoveBase>().Direction = direction;
        
        StartCoroutine(WaitingShoot(_bulletDelayShooting));
    }

    private void FireHardBullets(Vector2 direction)
    {
        if (!isReadyFire) return;
        isReadyFire = false;
        var index = GameManager.Instance.HardBullets.FindIndex(0, b => b.Type == CurrentHardBullet);
        var hard_bullet_1 = Instantiate(GameManager.Instance.HardBullets[index], _shootingPointsHardBullet[0].position, Quaternion.identity);
        hard_bullet_1.GetComponent<MoveBase>().Direction = direction;

        var hard_bullet_2 = Instantiate(GameManager.Instance.HardBullets[index], _shootingPointsHardBullet[1].position, Quaternion.identity);
        hard_bullet_2.GetComponent<MoveBase>().Direction = direction;

        StartCoroutine(WaitingShoot(_hardBulletDelayShooting));
    }

    private void FireRocket(Vector2 direction)
    {
        if (!isReadyFire) return;
        if (_ammunitions.CountRockets == 0) return;
        
        isReadyFire = false;

        var rocket = Instantiate(GameManager.Instance.Rockets[0], _shootingPointRocket.position, Quaternion.identity);
        rocket.GetComponent<MoveBase>().Direction = direction;

        _ammunitions.CountRockets--;

        StartCoroutine(WaitingShoot(_rocketDelayShooting));
    }

    IEnumerator WaitingShoot(float delayShooting)
    {
        yield return new WaitForSeconds(delayShooting);
        isReadyFire = true;
    }
}
