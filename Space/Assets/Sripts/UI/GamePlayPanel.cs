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
    public Action PauseEvent;
    void Start()
    {

    }

    void Update()
    {
        _health.UiHealth = GameManager.Instance.Player.Health.Health;
        _lifeTxt.text = GameManager.Instance.LIFE.ToString();
        _rocketsTxt.text = GameManager.Instance.Player.Ammunitions.CountRockets.ToString();
    }

    public void OnPause()
    {
        PauseEvent?.Invoke();
    }
}
