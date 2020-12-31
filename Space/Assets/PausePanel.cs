using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Color[] colorSound;
    [SerializeField] private Text soundTxt = null;
    public void TapSound(bool isSound)
    {
        if (AudioListener.volume > 0)
        {
            AudioListener.volume = 0f;
            soundTxt.color = colorSound[0];
        }
        else
        {
            AudioListener.volume = 1f;
            soundTxt.color = colorSound[1];
        }
    }

    public void TapMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
