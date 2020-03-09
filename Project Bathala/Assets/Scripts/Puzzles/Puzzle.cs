using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPuzzleCompleted : UnityEvent { }

public class Puzzle : MonoBehaviour
{
    [HideInInspector] public OnPuzzleCompleted completed = new OnPuzzleCompleted();

    protected bool isSolved = false;
    protected LevelManager manager;
    
    void Start()
    {
        manager = (SingletonManager.Manager != null) ? SingletonManager.Manager.GetSingleton<LevelManager>() : null;
        if (manager == null) return;
        manager.Register(this);
    }

}
