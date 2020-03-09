using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WallPuzzle : Puzzle
{
    public List<WallPuzzleSlot> slots = new List<WallPuzzleSlot>();

    void Update()
    {
        if (isSolved) return;
        if (slots.All(s => s.isCorrect))
        {
            completed.Invoke();
            Debug.Log("Puzzle Completed");
            isSolved = true;
        }
    }
}
