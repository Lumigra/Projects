using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialActivator : MonoBehaviour, IInteractable
{
    [HideInInspector] public OnActivated onActivated = new OnActivated();

    Player player;
    public void Interact(PlayerInteraction _player)
    {
        if (player == null)
        {
            player = _player.GetComponent<Player>();
            player.PlayerStatus.isInteracting = true;
            player.PlayerStatus.CanWalk = false;
            onActivated.Invoke(true);
        }

        else
        {
            player.PlayerStatus.isInteracting = false;
            player.PlayerStatus.CanWalk = true;
            player = null;
            onActivated.Invoke(false);
        }
    }
}
