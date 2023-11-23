using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPuzzleGate : MonoBehaviour
{
    public GameObject Gate;

    public WallPuzzle wallPuzzle;
    void Start()
    {
        wallPuzzle.completed.AddListener(OpenGate);
    }

    void OpenGate()
    {
        Gate.SetActive(false);
    }
}
