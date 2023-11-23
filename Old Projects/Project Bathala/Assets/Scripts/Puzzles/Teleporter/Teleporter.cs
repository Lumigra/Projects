using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform TeleportPoint;
    public Teleporter LinkedTeleporter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player == null) return;
        player.transform.position = LinkedTeleporter.TeleportPoint.position;
    }
}
