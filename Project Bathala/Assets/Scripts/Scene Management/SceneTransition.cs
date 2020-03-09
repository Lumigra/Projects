using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public string SceneName;

    private IEnumerator enumerator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>()) {
            collision.GetComponent<Player>().PlayerStatus.CanWalk = false;
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        if (enumerator != null)
            return;

        enumerator = TransitionProcess();
        StartCoroutine(enumerator);
    }
    public IEnumerator TransitionProcess()
    {

        Camera main = Camera.main;
        yield return StartCoroutine(main.GetComponent<ScreenFade>().Fade(true));
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName, LoadSceneMode.Additive);
        while (!operation.isDone) yield return null;
        yield return null;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));
        SceneManager.UnloadSceneAsync(gameObject.scene.name);
    }
}
