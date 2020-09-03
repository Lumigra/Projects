using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour {

    public GameObject GameOver;
	// Use this for initialization
	void Start () {
        GameOver.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenScreen()
    {
        GameOver.SetActive(true);
    }
}
