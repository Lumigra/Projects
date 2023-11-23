using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        
    }
    public void levelSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void loadLevel(int sceneNum)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneNum);
    }
   
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(gameObject.scene.name);
    }
}
