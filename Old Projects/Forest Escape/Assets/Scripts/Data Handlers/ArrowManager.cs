using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : GenericPooler<Arrow>
{
    public static ArrowManager Manager;

    private void Awake()
    {
        if (Manager == null) Manager = this;
        else Destroy(gameObject);
    }
}
