using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDurationExpired : UnityEvent<Arrow> { }
public class Arrow : MonoBehaviour, ILaning
{
    [HideInInspector] public OnDurationExpired Expired = new OnDurationExpired();
    public int Damage;
    public float Speed;
    public float LifeTime;
    public int LaneNo;

    [SerializeField]private float remainingTime;
    [SerializeField]private float trueSpeed;

    private SpriteRenderer renderer;

    private bool hasBroadcasted;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (hasBroadcasted) return;
        transform.position += new Vector3(trueSpeed, 0, 0) * Time.deltaTime;
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0) {
            Expired.Invoke(this);
            hasBroadcasted = true;
            Expired.RemoveAllListeners();
        }
    }
    public void SetSpeed(float speed)
    {
        trueSpeed = speed + Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ILaning>() == null) return;
        if (collision.GetComponent<ILaning>().GetLane() != LaneNo) return;
        if (collision.GetComponent<Health>())
        {
            collision.GetComponent<Health>().TakeDamage(Damage);
        }

        Expired.Invoke(this);
        hasBroadcasted = true;
        Expired.RemoveAllListeners();
        //Destroy(gameObject);
    }

    public void ChangeOrder()
    {
        SpriteOrderSetter setter = new SpriteOrderSetter(GetComponent<SpriteRenderer>(), LaneNo);
    }

    public int GetLane()
    {
        return LaneNo;
    }

    public void ResetTimer()
    {
        remainingTime = LifeTime;
        hasBroadcasted = false;
    }

    private void OnEnable()
    {
        ResetTimer();
    }
}
