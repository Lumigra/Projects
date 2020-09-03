using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI_Health : MonoBehaviour
{
    public Player Player;
    public TextMeshProUGUI TextMesh;
    private void Start()
    {
        Health health = Player.GetComponent<Health>();
        health.onHealthChanged.AddListener(ChangeHealth);
        TextMesh.text = "Health: " + health.MaxHealth.ToString();
    }

    void ChangeHealth(int health)
    {
        TextMesh.text = "Health: " + health.ToString();
    }
}
