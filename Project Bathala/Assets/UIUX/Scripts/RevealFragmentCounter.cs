using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevealFragmentCounter : MonoBehaviour
{
    private FragmentGate fragGate;
    private ArtifactManager am;

    public Animator FragCounterAnim;
    public Text FragCounterText;

    // Start is called before the first frame update
    void Start()
    {
        fragGate = GetComponent<FragmentGate>();
        am = SingletonManager.Manager.GetSingleton<LevelManager>().GetSingleton<ArtifactManager>();
    }

    private void Update()
    {
        FragCounterText.text = "x " + fragGate.RequiredFrag.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (am.currentFragments >= fragGate.RequiredFrag) return;
        if (collision.gameObject.GetComponent<Player>() == null) return;
        FragCounterAnim.SetBool("IsNearGate", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (am.currentFragments >= fragGate.RequiredFrag) return;
        if (collision.gameObject.GetComponent<Player>() == null) return;
        FragCounterAnim.SetBool("IsNearGate", false);
    }
}
