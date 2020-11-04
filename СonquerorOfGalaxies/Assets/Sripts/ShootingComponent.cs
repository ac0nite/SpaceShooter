using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    [SerializeField] private Transform _shootingPointBullet = null;
    [SerializeField] private List<Transform> _shootingPointsRockets = null;
    [SerializeField] private float _delayShooting = 1f;
    private bool isFire = true;

    public void FireBullet(Vector2 direction)
    {
        if (!isFire) return;

        isFire = false;
        var bullet = Instantiate(GameManager.Instance.Bullets[0], _shootingPointBullet.position, Quaternion.identity);
        bullet.GetComponent<MoveBase>().Direction = direction;

        StartCoroutine(WaitingShoot());
    }

    public void FireRockets(Vector2 direction)
    {
        if (!isFire) return;

        isFire = false;
        var rocket_1 = Instantiate(GameManager.Instance.Bullets[0], _shootingPointsRockets[0].position, Quaternion.identity);
        rocket_1.GetComponent<MoveBase>().Direction = direction;

        var rocket_2 = Instantiate(GameManager.Instance.Bullets[0], _shootingPointsRockets[1].position, Quaternion.identity);
        rocket_2.GetComponent<MoveBase>().Direction = direction;

        StartCoroutine(WaitingShoot());
    }

    IEnumerator WaitingShoot()
    {
        yield return new WaitForSeconds(_delayShooting);
        isFire = true;
    }
}
