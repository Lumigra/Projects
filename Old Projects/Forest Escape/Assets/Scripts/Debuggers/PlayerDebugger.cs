using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebugger : MonoBehaviour {

    public Player player;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (player.GetComponent<Shield>()) return;
            player.gameObject.AddComponent<Shield>();
        }
        if (Input.GetKeyDown(KeyCode.D)) player.GetComponent<Health>().TakeDamage(1);
        if (Input.GetKeyDown(KeyCode.H)) player.GetComponent<Health>().Heal(1);
        if (Input.GetKeyDown(KeyCode.A)) player.GetComponent<PlayerShoot>().AddAmmo(1);
	}
}
