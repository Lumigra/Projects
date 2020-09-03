using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Obstacle
{
    protected override void TriggerEffect(Collider2D collider)
    {
        Health health = collider.GetComponent<Health>();
        health.TakeDamage(Damage);
    }
}
