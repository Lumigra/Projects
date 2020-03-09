using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    private SceneTransition transition;

    private void Start()
    {
        transition = GetComponent<SceneTransition>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            //if (EventSystem.current.IsPointerOverGameObject()) return;
            transition.ChangeScene();
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#elif UNITY_STANDALONE
        Application.Quit();
#endif
    }
}
