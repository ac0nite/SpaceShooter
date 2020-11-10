using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    [SerializeField] private Transform _shootingPointBullet = null;
    [SerializeField] private List<Transform> _shootingPointsRockets = null;
    [SerializeField] private float _delayShooting = 1f;
    private Vector2 _direction = Vector2.right;
    private bool isFireBullet = false;
    private bool isFireRockets = false;
    private bool isReadyFire = true;

    void Update()
    {
        if(isFireBullet) FireBullet(_direction);
        if (isFireRockets) FireRockets(_direction);
    }

    public void Fire(TypeAmmunition type, Vector2 direction, bool isPressFire)
    {
        //Debug.Log($"isPressFire: {isPressFire}");
        _direction = direction;
        if (type == TypeAmmunition.Bullet) isFireBullet = isPressFire;
        else if (type == TypeAmmunition.Rocket) isFireRockets = isPressFire;
    }

    private void FireBullet(Vector2 direction)
    {
        if (!isReadyFire) return;

        isReadyFire = false;
        var bullet = Instantiate(GameManager.Instance.Bullets[0], _shootingPointBullet.position, Quaternion.identity);
        bullet.GetComponent<MoveBase>().Direction = direction;

        //Debug.Log($"FireBullet", bullet.gameObject);

        StartCoroutine(WaitingShoot());
    }

    private void FireRockets(Vector2 direction)
    {
        if (!isReadyFire) return;

        isReadyFire = false;
        var rocket_1 = Instantiate(GameManager.Instance.Bullets[0], _shootingPointsRockets[0].position, Quaternion.identity);
        rocket_1.GetComponent<MoveBase>().Direction = direction;

        var rocket_2 = Instantiate(GameManager.Instance.Bullets[0], _shootingPointsRockets[1].position, Quaternion.identity);
        rocket_2.GetComponent<MoveBase>().Direction = direction;

        StartCoroutine(WaitingShoot());
    }

    IEnumerator WaitingShoot()
    {
        yield return new WaitForSeconds(_delayShooting);
        isReadyFire = true;
    }
}
