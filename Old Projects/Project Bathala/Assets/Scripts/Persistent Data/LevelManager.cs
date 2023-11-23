using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class GameState
{
    public bool IsPaused;
}

public class LevelManager : MonoBehaviour
{
    public GameState GameState = new GameState();

    private SingletonManager manager;
    private List<MonoBehaviour> LocalSingletons = new List<MonoBehaviour>();
    private void Awake()
    {
        GameState.IsPaused = false;
        manager = SingletonManager.Manager;
        if (SingletonManager.Manager == null) return;
        SingletonManager.Manager.Register(this);
        SceneManager.sceneUnloaded += SceneUnloaded;
    }

    private void SceneUnloaded(Scene scene)
    {
        foreach (MonoBehaviour singleton in LocalSingletons.ToList())
        {
            if (singleton.gameObject.scene == scene)
            {
                LocalSingletons.Remove(singleton);
            }
        }
    }

    public void Register<T>(T param) where T : MonoBehaviour
    {
        if (!LocalSingletons.Exists(s => s is T)) LocalSingletons.Add(param);
    }

    public void Unregister<T>(T param) where T : MonoBehaviour
    {
        if (LocalSingletons.Exists(s => s is T)) LocalSingletons.Remove(param);
    }

    public T GetSingleton<T>() where T : MonoBehaviour
    {
        T temp = null;
        for (int x = 0; x < LocalSingletons.Count; x++)
        {
            if (LocalSingletons[x] is T)
            {
                temp = LocalSingletons[x] as T;
                break;
            }
        }
        return temp;
    }

    private void OnDestroy()
    {
        LocalSingletons.Clear();
    }

    public void LoadLevel(string levelToLoad, string currentLevel)
    {
        StartCoroutine(LoadProcess(levelToLoad, currentLevel));
    }

    public IEnumerator LoadProcess(string levelToLoad, string currentLevel)
    {
        Camera main = Camera.main;
        yield return StartCoroutine(main.GetComponent<ScreenFade>().Fade(true));
        SceneManager.UnloadSceneAsync(currentLevel);
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync(levelToLoad, LoadSceneMode.Additive);

        for (; !loadLevel.isDone;)
            yield return null;
        manager.Unregister(this);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelToLoad));
        SceneManager.UnloadSceneAsync(gameObject.scene.name);
    }
    public IEnumerator UnloadData(string currentLevel)
    {
        SceneManager.UnloadSceneAsync(currentLevel);
        SceneManager.UnloadSceneAsync(gameObject.scene.name);
        yield return null;
    }

    public void PauseGame()
    {
        if(!GameState.IsPaused)
        {
            GameState.IsPaused = true;
            Time.timeScale = 0.0f;
        }
        else
        {
            GameState.IsPaused = false;
            Time.timeScale = 1.0f;
        }
    }
}
