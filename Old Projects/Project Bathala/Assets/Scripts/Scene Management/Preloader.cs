using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Preloader : MonoBehaviour
{
    public string SceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        //if (!SceneManager.GetSceneByName("UI").isLoaded) SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        if (SceneManager.GetSceneByName(SceneToLoad).isLoaded) return;
        SceneManager.LoadSceneAsync(SceneToLoad, LoadSceneMode.Additive);
    }
}