using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : InteractableSwitch
{
    private bool isPressed;
    protected override void Activate()
    {
        if(!isPressed) StartCoroutine(ActivateButton());
    }

    IEnumerator ActivateButton()
    {
        activated.Invoke(true);
        isPressed = true;
        sRenderer.sprite = ActiveState;
        yield return new WaitForSeconds(1.0f);
        isPressed = false;
        sRenderer.sprite = InactiveState;
    }
}
