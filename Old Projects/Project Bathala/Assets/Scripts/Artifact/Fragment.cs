using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{
    private ArtifactManager manager;
    void Start()
    {
        manager = (SingletonManager.Manager != null) ?
            SingletonManager.Manager.GetSingleton<LevelManager>().GetSingleton<ArtifactManager>() : null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (collision == null) return;

        if(manager != null) manager.IncreaseFragmentCount();
        Debug.Log("Fragment Collected");
        Destroy(gameObject);
    }
}
