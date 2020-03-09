using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DialPuzzle : Puzzle
{
    public List<int> CorrectPositions = new List<int>();
    public List<Dial> Rings = new List<Dial>();
    public DialActivator Activator;

    /*[HideInInspector]*/ public int RingCount;
    /*[HideInInspector]*/ public int CurrentRingNumber { get; private set; }

    private Dial currentRing;
    void Start()
    {
        if (Rings.Count < CorrectPositions.Count || CorrectPositions.Count < Rings.Count)
        {
            throw new UnityException("Uneven Dials and Positions");
        }

        //Arrange the dials by position, then set the first dial to currentDial
        Rings = Rings.OrderBy(s => s.DialNumber).ToList();
        currentRing = Rings.First();

        RingCount = Rings.Count;
        CurrentRingNumber = currentRing.Position;

        //Add listeners when dials are interacted
        foreach(Dial dial in Rings.ToList())
        {
            dial.dialChange.AddListener(ChangeDial);
            dial.dialSpun.AddListener(CheckPuzzle);
            dial.SetActive(false);
        }
        if (currentRing == null) throw new UnityException("No currentDial");

        Activator.onActivated.AddListener(ActivatePuzzle);
    }

    void ChangeDial(int value)
    {
        if (Rings.Count <= 1) return;
        if (currentRing.DialNumber + value - 1 >= Rings.Count || currentRing.DialNumber + value - 1 < 0) return;
        Dial toActivate = Rings[currentRing.DialNumber + value - 1];

        currentRing.SetActive(false);
        toActivate.SetActive(true);
        currentRing = toActivate;

        CurrentRingNumber = currentRing.Position;
    }

    void CheckPuzzle()
    {
        if (isSolved) return;

        bool isPuzzleSolved = true;
        for(int x = 0; x < Rings.Count; x++)
        {
            if (Rings[x].Position == CorrectPositions[x]) continue;
            isPuzzleSolved = false;
            break;
        }

        if (isPuzzleSolved)
        {
            isSolved = true;
            completed.Invoke();
            Debug.Log("Completed");
        }
    }

    void ActivatePuzzle(bool willActivate)
    {
        if (willActivate) currentRing.SetActive(true);
        else currentRing.SetActive(false);
    }
}
