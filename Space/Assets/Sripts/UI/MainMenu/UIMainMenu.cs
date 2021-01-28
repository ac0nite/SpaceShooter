using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    }
    private void Start()
    {
        _coins.text = Saving.Instance.data.Coins.ToString();
        _highscore.text = Saving.Instance.data.HighScore.ToString();

        payAndPlayButton.onClick.AddListener(OnPlay);

        _shipManager.EventSelectShip += OnSelectShip;
    }

    public void OnSelectShip(UIShipUse ship)
    {
        payAndPlayButton.onClick.RemoveAllListeners();

        if (ship.IsLock == StateLock.LOCK)
        {
            _shipManager.Name.text = $"{ship.Name} ({ship.Cost} coins)";

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
        if (_shipManager.SelectShip.Cost > Saving.Instance.data.Coins)
        {
            //TODO здесь будет реализованно предложение о покупке кораблика
            return;
        }

        Saving.Instance.data.Coins -= _shipManager.SelectShip.Cost;
        _coins.text = Saving.Instance.data.Coins.ToString();
        _shipManager.SelectShip.IsLock = StateLock.UNLOCK;

        OnSelectShip(_shipManager.SelectShip);

        Saving.Instance.UpdateShips(_shipManager.Content);
    }

    private void OnPlay()
    {
        Debug.Log("play");
    }

    private void OnDestroy()
    {
        _shipManager.EventSelectShip -= OnSelectShip;
    }

    public void ClickQuit()
    {
        Saving.Instance.UpdateShips(_shipManager.Content);
        Saving.Instance.UpdateStage(_stageManager.Content);
        Saving.Instance.Write();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
