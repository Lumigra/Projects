using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus
{
    public bool canInteract = true;
    public bool CanWalk = true;
    public bool isTalking = false;
    public bool isInteracting = false;
}

public class Player : MonoBehaviour
{
    public Health health { get; private set; }
    public PlayerMovement movement { get; private set; }
    public PlayerDialogue dialogue { get; private set; }
    [HideInInspector] public PlayerStatus PlayerStatus = new PlayerStatus();

    void Start()
    {
        try
        {
            health = GetComponent<Health>();
        }
        catch
        {
            Debug.Log("No health attached");
        }
        finally
        {
            health.onZeroHealth.AddListener(Die);

        }
        try
        {
            movement = GetComponent<PlayerMovement>();
        }
        catch
        {
            Debug.Log("No player movement attached");
        }
        try
        {
            dialogue = GetComponent<PlayerDialogue>();
        }
        catch
        {
            Debug.Log("No dialogue system attached");
        }

    }

    public void Die()
    {

    }
}
