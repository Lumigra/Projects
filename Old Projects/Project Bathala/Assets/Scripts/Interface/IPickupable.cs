using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    void Pickup(PlayerInteraction player);
    void Drop(PlayerInteraction player);
}
