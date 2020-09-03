using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : GenericPooler<Enemy>
{
    public static EnemyManager Manager;

    private void Awake()
    {
        if (Manager == null) Manager = this;
        else Destroy(gameObject);
    }
}
