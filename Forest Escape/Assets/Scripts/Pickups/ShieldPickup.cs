using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : Pickup
{
    protected override void TriggerEffect(Collider2D collider)
    {
        if (!collider.GetComponent<Shield>())
        {
            collider.gameObject.AddComponent<Shield>();
            collider.GetComponent<Health>().ShieldSprite.gameObject.SetActive(true);
        }
        pickedUp.Invoke(this);
    }
}
