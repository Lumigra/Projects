using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : Pickup {
    public int AmmoCount;

    protected override void TriggerEffect(Collider2D collider)
    {
        PlayerShoot pShoot = collider.GetComponent<PlayerShoot>();
        if (pShoot == null) return;

        pShoot.AddAmmo(AmmoCount);
        pickedUp.Invoke(this);
    }
}
