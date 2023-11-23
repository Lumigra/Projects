using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAnimation : MonoBehaviour
{
    public bool UseSideFacingAnimation;

    private void Start()
    {
        GetComponent<Animator>().SetBool("TorchDirection", UseSideFacingAnimation);
    }
}
