using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    public string LevelToLoad;

    private LevelManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = SingletonManager.Manager.GetSingleton<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Player>().PlayerStatus.CanWalk = false;
        if (collision.GetComponent<Player>())
            manager.LoadLevel(LevelToLoad, gameObject.scene.name);
    }
}
