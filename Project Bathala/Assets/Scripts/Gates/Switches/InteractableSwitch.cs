using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSwitch : Switch, IInteractable
{
    public void Interact(PlayerInteraction player)
    {
        Activate();
    }


}
