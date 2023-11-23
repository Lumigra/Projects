using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractableSwitch
{
    private bool isActivated = false;

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }


    protected override void Activate()
    {
        if (isActivated == false)
        {
            isActivated = true;
            sRenderer.sprite = ActiveState;
        }
        else
        {
            isActivated = false;
            sRenderer.sprite = InactiveState;
        }
        activated.Invoke(isActivated);
    }
}
