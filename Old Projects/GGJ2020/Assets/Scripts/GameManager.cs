using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //public int Lower1Star;
    //public int Upper1Star;
    //public int Lower2Star;
    //public int Upper2Star;
    //public int Lower3Star;
    //public int Upper3Star;

    public static GameManager Manager;

    public Text ScoreText;
    public CountdownScript timer;
    public GameObject GameOverScreen;
    public GameObject WinScreen;
    private int totalRepairedObjects = 0;
    public bool IsGamePaused { get; private set; }
    //hello

    private void Awake()
    {
        if (Manager != null)
            Destroy(gameObject);
        Manager = this;
    }

    private void Start()
    {
        IsGamePaused = true;
        timer.timerUp.AddListener(OnTimerUp);
        UpdateScore();
        GameOverScreen.SetActive(false);
        WinScreen.SetActive(false);
        InteractableObjectsHandler.IObjHandler.allObjDestroyed.AddListener(OnAllObjDestroyed);

        StartCoroutine(Startup());
    }

    IEnumerator Startup()
    {
        yield return new WaitForSeconds(3.0f);

        IsGamePaused = false;
    }

    public void IncreaseRepairedCount()
    {
        totalRepairedObjects++;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = totalRepairedObjects.ToString();
    }

    void OnTimerUp()
    {
        WinScreen.SetActive(true);
        IsGamePaused = true;
    }

    void OnAllObjDestroyed()
    {
        GameOverScreen.SetActive(true);
        IsGamePaused = true;
    }
}
