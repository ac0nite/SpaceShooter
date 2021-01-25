using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private StagesManagment _stageManager = null;
    [SerializeField] private ShipsManagment _shipManager = null;
    [SerializeField] private Text _coins;
    [SerializeField] private Text _highscore;
    [SerializeField] private Text _version;
    [SerializeField] private Button payAndPlayButton = null;

    private void Awake()
    {
        _version.text = Application.version.ToString();
        _coins.text = "0";
        _highscore.text = "0";
        _shipManager.EventSelectShip += OnSelectShip;
        Saving.Instance.Read();
        Saving.Instance.UpdateShips(_shipManager.Content);
        //Saving.Instance.UpdateStage(_stageManager.Content);
    }
    private void Start()
    {
       // _stageManager.Stages[0].IsSelect = StateSelect.SELECT;
       // _shipManager.Ships[0].IsSelect = StateSelect.SELECT;
    }

    public void OnSelectShip(UIShipUse ship)
    {
        payAndPlayButton.onClick.RemoveAllListeners();

        if (ship.IsLock == StateLock.LOCK)
        {
            payAndPlayButton.GetComponentInChildren<Text>().text = "Pay";
            payAndPlayButton.onClick.AddListener(OnPay);
        }
        else
        {
            payAndPlayButton.GetComponentInChildren<Text>().text = "Play";
            payAndPlayButton.onClick.AddListener(OnPlay);
        }
    }

    private void OnPay()
    {
        Debug.Log("pay");
    }

    private void OnPlay()
    {
        Debug.Log("play");
    }

    private void OnDestroy()
    {
        _shipManager.EventSelectShip -= OnSelectShip;
        Saving.Instance.Write();
    }
}
