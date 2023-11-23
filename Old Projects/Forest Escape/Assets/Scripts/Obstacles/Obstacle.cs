using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour, ILaning
{
    public int Damage;
    public int LaneNo;


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ILaning>() == null) return;
        if (collision.GetComponent<ILaning>().GetLane() != LaneNo) return;
        if (collision.GetComponent<Player>()) TriggerEffect(collision);
    }

    protected virtual void TriggerEffect(Collider2D collider)
    {

    }

    public void ChangeOrder()
    {
        SpriteOrderSetter setter = new SpriteOrderSetter(GetComponent<SpriteRenderer>(), LaneNo);
    }

    public int GetLane()
    {
        return LaneNo;
    }
}
