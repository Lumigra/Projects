using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppableTile : MonoBehaviour, IInteractable, IPickupable
{
    public void Interact(PlayerInteraction player)
    {
        if (player.PickedUpObj == null) Pickup(player);
        else if (player.PickedUpObj != null && player.interactable != null) player.SwapItem(this);
        else Drop(player);
    }

    public void Pickup(PlayerInteraction player)
    {
        player.PickedUpObj = gameObject;
        gameObject.SetActive(false);
    }

    public void Drop(PlayerInteraction player)
    {
        gameObject.SetActive(true);
        transform.position = player.transform.position;
        player.PickedUpObj = null;
    }


}
