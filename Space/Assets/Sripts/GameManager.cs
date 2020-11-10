using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletoneGameObject<GameManager>
{
    [SerializeField] public Transform GenerateTransform = null;
    [SerializeField] public List<Color> ColorsStars = null;
    [SerializeField] public List<Weapon> Bullets = null;
    [SerializeField] public List<EnemyController> Enemy = null;
    [SerializeField] public GameObject Player = null;
    [SerializeField] public List<MineController> Mines = null;
}
