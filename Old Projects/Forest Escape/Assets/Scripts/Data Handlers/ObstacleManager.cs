using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : GenericPooler<Obstacle>
{
    public static ObstacleManager Manager;

    private void Awake()
    {

        if (Manager == null) Manager = this;
        else Destroy(gameObject);
    }
}
