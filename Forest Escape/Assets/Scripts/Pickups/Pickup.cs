using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPickedUp : UnityEvent<Pickup> { }

public class Pickup : MonoBehaviour, ILaning
{
    [HideInInspector] public OnPickedUp pickedUp = new OnPickedUp();
    public int LaneNo;


    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ILaning>() == null) return;
        if (collision.GetComponent<ILaning>().GetLane() != LaneNo) return;
        if (collision.GetComponent<Player>()) TriggerEffect(collision);
    }

    protected virtual void TriggerEffect(Collider2D collider)
    {
        Debug.Log("Picked up");
        pickedUp.Invoke(this);
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
