using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int highScore = 0;
    [SerializeField] private int score = 0;
    private int coins = 0;

    public int Coins
    {
        get { return coins; }
        set
        {
            coins = Mathf.Clamp(value, 0, int.MaxValue);
        }
    }
    public int Score
    {
        get { return score;}
        set
        {
            if (value > 0)
            {
                score += value;
                if (score > HighScore)
                    highScore = score;
            }
        }
    }
    public int HighScore
    {
        get { return highScore;}
    }

    private void OnDestroy()
    {
        Save();
    }
    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        coins = PlayerPrefs.GetInt("Coins", 0);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
    }
}
