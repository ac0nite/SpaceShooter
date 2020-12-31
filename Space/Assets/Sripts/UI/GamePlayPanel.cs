using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayPanel : MonoBehaviour
{
    [SerializeField] private UIHealth _health = null;
    [SerializeField] private Text _lifeTxt = null;
    [SerializeField] private Text _rocketsTxt = null;
    [SerializeField] private Text _coinsTxt = null;
    [SerializeField] private PausePanel pausePanel = null;
    public Action PauseEvent;
    
    void Start()
    {

    }

    void Update()
    {
        _health.UiHealth = GameManager.Instance.Player.Health.Health;
        _lifeTxt.text = GameManager.Instance.LIFE.ToString();
        _rocketsTxt.text = GameManager.Instance.Player.Ammunitions.CountRockets.ToString();
        _coinsTxt.text = GameManager.Instance.ScoreManager.Coins.ToString();
    }

    public void TapPause(bool isPause)
    {
        if (isPause)
        {
            Time.timeScale = 0.00001f;
            PauseEvent?.Invoke();
            pausePanel.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.gameObject.SetActive(false);
        }
    }

    public void OnPause()
    {
        Time.timeScale = 0.00001f;
        PauseEvent?.Invoke();
        pausePanel.gameObject.SetActive(true);
    }
}
