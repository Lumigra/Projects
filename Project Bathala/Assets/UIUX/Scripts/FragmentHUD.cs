using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragmentHUD : MonoBehaviour
{
    private Text fragCountHUD;
    private ArtifactManager am;

    // Start is called before the first frame update
    void Start()
    {
        fragCountHUD = GetComponent<Text>();
        am = SingletonManager.Manager.GetSingleton<LevelManager>().GetSingleton<ArtifactManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (am != null)
            fragCountHUD.text = "x " + am.currentFragments.ToString();
        else Debug.Log("Artifact Manager is null");
    }
}
