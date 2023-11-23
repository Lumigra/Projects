using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PickupManager : GenericPooler<Pickup>
{
    public static PickupManager Manager;

    private void Awake()
    {
        if (Manager == null) Manager = this;
        else Destroy(gameObject);
    }
}
