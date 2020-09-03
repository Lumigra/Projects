using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnPlayerDied : UnityEvent { }
public class Player : MonoBehaviour, ILaning
{

    [HideInInspector] public OnPlayerDied onPlayerDied = new OnPlayerDied();
    public Health Health { get; private set; }
    public PlayerMovement PMove { get; private set; }

    private void Start()
    {
        try
        {
            Health = GetComponent<Health>();
            Health.onHealthZero.AddListener(Die);

            if (GetComponent<Shield>()) Health.ShieldSprite.gameObject.SetActive(true);
            else Health.ShieldSprite.gameObject.SetActive(false);
        }
        catch
        {
            Debug.Log("No health attached");
        }
        try
        {
            PMove = GetComponent<PlayerMovement>();
        }
        catch
        {
            Debug.Log("No player movement attached");
        }

    }

    public void Die()
    {
        onPlayerDied.Invoke();
        Destroy(gameObject);
    }

    public int GetLane()
    {
        return PMove.GetLaneNo();
    }
}
