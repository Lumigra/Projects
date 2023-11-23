using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnHealthChanged : UnityEvent<int> { }
public class OnHealthZero : UnityEvent { }
public class Health : MonoBehaviour
{
    [HideInInspector] public OnHealthChanged onHealthChanged = new OnHealthChanged();
    [HideInInspector] public OnHealthZero onHealthZero = new OnHealthZero();
    public int MaxHealth;
    public SpriteRenderer ShieldSprite;

    public int CurrentHealth { get; private set; }

	void Start () {
        SetHealth(MaxHealth);
        if (CurrentHealth == 0) throw new UnityException("Health cannot be zero by default");
	}
	
    public void Heal(int healValue)
    {
        CurrentHealth += healValue;
        if (CurrentHealth > MaxHealth) CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damageValue)
    {
        if(GetComponent<Shield>())
        {
            GetComponent<Shield>().DestroyShield();
            ShieldSprite.gameObject.SetActive(false);
        }

        else
        {
            CurrentHealth -= damageValue;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                onHealthZero.Invoke();
            }
            onHealthChanged.Invoke(CurrentHealth);
        }
    }

    public void TakeDamage(int damageValue, bool ignoresShield)
    {
        if (GetComponent<Shield>() && !ignoresShield)
        {
            GetComponent<Shield>().DestroyShield();
            ShieldSprite.gameObject.SetActive(false);
        }

        else
        {
            CurrentHealth -= damageValue;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                onHealthZero.Invoke();
            }
            onHealthChanged.Invoke(CurrentHealth);
        }
    }

    public void SetHealth(int value)
    {
        CurrentHealth = value;
        onHealthChanged.Invoke(CurrentHealth);
    }
}
