using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnemyDestroyed : UnityEvent<Enemy> { }

public class Enemy : MonoBehaviour, ILaning
{
    [HideInInspector] public OnEnemyDestroyed enemyDestroyed = new OnEnemyDestroyed();

    public int Damage;
    public int LaneNo;
    public int ScoreValue;
    public float LifeTime;

    private Health health;
    private float remainingTime;
    private bool hasBraodcasted;
    private void Start()
    {
        remainingTime = LifeTime;
        health = GetComponent<Health>();
        health.onHealthZero.AddListener(OnHealthZero);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ILaning>() == null) return;
        if (collision.GetComponent<ILaning>().GetLane() != LaneNo) return;
        if (collision.GetComponent<Player>()) TriggerEffect(collision);
    }

    protected virtual void TriggerEffect(Collider2D collider)
    {
        GameScene.gameScene.IncreaseScore(ScoreValue);
        collider.GetComponent<Player>().Health.TakeDamage(Damage);
    }

    void OnHealthZero()
    {
        enemyDestroyed.Invoke(this);
    }

    private void OnEnable()
    {
        if (health != null) health.SetHealth(health.MaxHealth);
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
