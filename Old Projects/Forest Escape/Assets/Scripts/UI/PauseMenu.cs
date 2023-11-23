using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseButton;
    public GameObject PauseScreen;


    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = true;
        PauseButton.SetActive(true);
        PauseScreen.SetActive(false);
    }

    public void PauseGame(bool willPause)
    {
        isPaused = willPause;
        if(isPaused)
        {
            PauseButton.SetActive(false);
            PauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseButton.SetActive(true);
            PauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
