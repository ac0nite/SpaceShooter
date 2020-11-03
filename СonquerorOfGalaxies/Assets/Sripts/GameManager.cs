using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletoneGameObject<GameManager>
{
    [SerializeField] public Transform GenerateTransform = null;
    [SerializeField] public List<Color> ColorsStars = null;
}
