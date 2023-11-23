using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGate : MonoBehaviour
{
    public GameObject Gate;

    public Puzzle Puzzle;

    void Start()
    {
        Puzzle.completed.AddListener(OpenGate);
    }

    void OpenGate()
    {
        Gate.SetActive(false);
    }
}
