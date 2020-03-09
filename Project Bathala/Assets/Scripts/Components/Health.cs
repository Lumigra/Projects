using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnGainedHealth : UnityEvent<Health> { }
public class OnLostHealth : UnityEvent<Health> { }
public class OnZeroHealth : UnityEvent { }
public class Health : MonoBehaviour
{
    [HideInInspector] public OnGainedHealth onGainedHealth = new OnGainedHealth();
    [HideInInspector] public OnLostHealth onLostHealth = new OnLostHealth();
    [HideInInspector] public OnZeroHealth onZeroHealth = new OnZeroHealth();

    public int MaxHealth;
    public int CurrentHealth { get; private set; }
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void Heal(int healValue)
    {
        CurrentHealth += healValue;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
        onGainedHealth.Invoke(this);
    }

    public void TakeDamage(int damageValue)
    {
        CurrentHealth -= damageValue;
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
            onLostHealth.Invoke(this);
            onZeroHealth.Invoke();
        }
        else onLostHealth.Invoke(this);
    }
}
