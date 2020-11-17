using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawn : MonoBehaviour
{
    [SerializeField] private bool isGenerate = true;
    [SerializeField] private float delayGenerateTime = 2f;
    private Vector2 scope = Vector2.zero;

    void Awake()
    {
        scope = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
    }

    void Start()
    {
        if (isGenerate)
            InvokeRepeating("Spawn", 1f, delayGenerateTime);
    }

    private void Spawn()
    {
        var enemy = Instantiate(
            GameManager.Instance.Bonus[Random.Range(0, GameManager.Instance.Bonus.Count)],
            new Vector3(GameManager.Instance.GenerateTransform.position.x,
                UnityEngine.Random.Range(-scope.y + 0.5f, +scope.y - 0.5f), 0f),
            Quaternion.identity
        );
    }
}
