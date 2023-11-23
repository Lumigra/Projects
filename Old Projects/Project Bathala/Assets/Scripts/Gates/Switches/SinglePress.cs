using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePress : InteractableSwitch
{
    protected override void Activate()
    {
        activated.Invoke(true);
        sRenderer.sprite = ActiveState;
    }
}
