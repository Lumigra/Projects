using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentGate : MonoBehaviour
{
    public int RequiredFrag;
    public GameObject Gate;

    private ArtifactManager manager;
    void Start()
    {
        manager = (SingletonManager.Manager != null) ? SingletonManager.Manager.GetSingleton<LevelManager>().GetSingleton<ArtifactManager>() : null;
        if (manager == null) return;
        manager.fragmentCollected.AddListener(OpenGate);
    }

    void OpenGate(int fragmentCount)
    {
        if (fragmentCount == RequiredFrag) Gate.SetActive(false);
    }
}
