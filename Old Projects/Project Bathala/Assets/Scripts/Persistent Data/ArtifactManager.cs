using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnArtifactCompleted : UnityEvent { }
public class OnFragmentCollected : UnityEvent<int> { }
public class ArtifactManager : MonoBehaviour
{
    [HideInInspector] public OnArtifactCompleted artifactCompleted = new OnArtifactCompleted();
    [HideInInspector] public OnFragmentCollected fragmentCollected = new OnFragmentCollected();

    public int FragmentCount;
    public int currentFragments { get; private set; }


    private LevelManager manager;
    void Start()
    {
        try { manager = SingletonManager.Manager.GetSingleton<LevelManager>(); }
        catch { Debug.Log("No manager detected"); }
        if (manager != null) manager.Register(this);
        currentFragments = 0;
    }

    public void IncreaseFragmentCount()
    {
        currentFragments++;
        fragmentCollected.Invoke(currentFragments);
        if (currentFragments == FragmentCount) artifactCompleted.Invoke();
    }

}
