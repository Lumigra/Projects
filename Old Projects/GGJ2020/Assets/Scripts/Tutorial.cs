using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Canvas Letter;
    public Canvas tutorial;
    public Canvas Dogs;
    void Start()
    {
        Letter.enabled = true;
        tutorial.enabled = false;
        Dogs.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LetterNext()
    {
        Letter.enabled = false;
        tutorial.enabled = true;
        Dogs.enabled = false;
    }
    public void TutorialNext()
    {
        Letter.enabled = false;
        tutorial.enabled = false;
        Dogs.enabled = true;
    }
}
