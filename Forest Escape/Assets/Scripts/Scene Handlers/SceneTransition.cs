using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public string SceneName;

    public void LoadScene()
    {
        StartCoroutine(HandleTransition());
    }

    IEnumerator HandleTransition()
    {
        Time.timeScale = 1;
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        while (!sceneLoading.isDone) yield return null;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));
        SceneManager.UnloadSceneAsync(gameObject.scene);
        yield return null;
    }
}
