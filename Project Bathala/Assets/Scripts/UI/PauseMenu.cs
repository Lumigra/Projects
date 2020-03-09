using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string HomeScene;
    public KeyCode PauseKey = KeyCode.Escape;
    public GameObject PauseButton;
    public GameObject PauseScreen;
    private LevelManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = SingletonManager.Manager.GetSingleton<LevelManager>();
        PauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(PauseKey)) Pause();
    }

    public void Pause()
    {
        manager.PauseGame();
        if (manager.GameState.IsPaused)
        {
            PauseButton.SetActive(false);
            PauseScreen.SetActive(true);
        }

        else
        {
            PauseScreen.SetActive(false);
            PauseButton.SetActive(true);
        }
    }

    public void ReturnHome()
    {
        manager.LoadLevel(HomeScene, gameObject.scene.name);
    }
}
