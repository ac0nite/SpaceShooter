using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletoneGameObject<GameManager>
{
    [SerializeField] public int LIFE = 3;

    [SerializeField] public Transform GenerateTransform = null;
    [SerializeField] public List<Color> ColorsStars = null;
    [SerializeField] public List<Bullet> Bullets = null;
    [SerializeField] public List<HardBullet> HardBullets = null;
    [SerializeField] public List<EnemyController> Enemy = null;
    [SerializeField] public ShipController Player = null;
    [SerializeField] public List<Mine> Mines = null;
    [SerializeField] public List<Rocket> Rockets = null;
    [SerializeField] public List<Bonus> Bonus = null;

    [SerializeField] private ParticleSystem explosion = null;

    void Start()
    {
        StartCoroutine(test());
    }

    IEnumerator test()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.5f);
            explosion.Play();
        }
    }
}
