using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class SpawnStars : MonoBehaviour
{

    [SerializeField] private List<GameObject> _prefabsStars = null;
    [SerializeField] private int kGenerate = 10;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        var position = GameManager.Instance.GenerateTransform.position;
        if (UnityEngine.Random.Range(0, kGenerate) == 0)
        {
            var star = Instantiate(
                _prefabsStars[UnityEngine.Random.Range(0, _prefabsStars.Count)],
                new Vector3(position.x, UnityEngine.Random.Range(-5f, 5f), 0f),
                Quaternion.identity,
                GameManager.Instance.GenerateTransform
            );
            star.GetComponent<SpriteRenderer>().color =
                GameManager.Instance.ColorsStars[Random.Range(0, GameManager.Instance.ColorsStars.Count)];
            
            var scale = Random.Range(1f, star.transform.localScale.x);
            star.transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
