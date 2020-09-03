using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnGameDataUpdated : UnityEvent { }
public class OnScoreChange : UnityEvent<double> { }
public class GameScene : MonoBehaviour {
    [HideInInspector] public OnScoreChange scoreChange = new OnScoreChange();
    [HideInInspector] public OnGameDataUpdated dataUpdated = new OnGameDataUpdated();

    public static GameScene gameScene;

    public float TimeToUpdate;

    public GameData SpawnerData;
    public GameOver GameOverScreen;
    public GameOverScreen screen;
    public Player Player;

    private int currentSpawnSet;
    private float currentTimer;
    public double ScoreRate;
    public double Score { get; private set; }
    private bool playerAlive;

    private void Awake()
    {
        if (gameScene != null)
            Destroy(gameObject);
        else
            gameScene = this;

        currentSpawnSet = 0;
        SpawnerData.GetNextSpawnData(currentSpawnSet);
    }

    void Start()
    {
        currentTimer = 0;
        //GameOverScreen.gameObject.SetActive(false);
        playerAlive = true;
        Score = 0;
        Player.onPlayerDied.AddListener(OnPlayerDied);
    }

    void Update()
    {
        if (playerAlive)
        {
            currentTimer += Time.deltaTime;
            if(currentTimer >= TimeToUpdate)
            {
                AdvanceSet();
                currentTimer = 0;
            }

            Score += ScoreRate * Time.deltaTime;
            scoreChange.Invoke(System.Math.Round(Score, 2));
        }
    }

    void OnPlayerDied()
    {
        playerAlive = false;
        //GameOverScreen.gameObject.SetActive(true);
        screen.OpenScreen();
        GameOverScreen.SetText(Mathf.Round((float)Score));
        Time.timeScale = 0;
    }

    public void IncreaseScore(int bonusScore)
    {
        Score += bonusScore;
    }

    void AdvanceSet()
    {
        if (currentSpawnSet == SpawnerData.GetSetCount() - 1) return;
        currentSpawnSet++;
        SpawnerData.GetNextSpawnData(currentSpawnSet);
        dataUpdated.Invoke();
        Debug.Log("Set updated");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(gameObject.scene.name);
    }
}
