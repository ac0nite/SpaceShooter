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
        //Debug.Log($"GameManager.Instance.Player._health.Health: {GameManager.Instance.Player._health.Health}");
        _health.UiHealth = GameManager.Instance.Player._health.Health;
        _lifeTxt.text = GameManager.Instance.LIFE.ToString();
        _rocketsTxt.text = GameManager.Instance.Player._shooting.CountRockets.ToString();
    }

    public void OnPause()
    {
        PauseEvent?.Invoke();
    }
}
