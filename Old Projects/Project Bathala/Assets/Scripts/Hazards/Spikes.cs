using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Player player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Player>() == null) return;

        player = collision.collider.GetComponent<Player>();

        player.gameObject.GetComponent<Health>().TakeDamage(1);

        StartCoroutine(ColorDelay(player));        

        player = null;
    }

    private IEnumerator ColorDelay(Player p)
    {
        p.GetComponent<SpriteRenderer>().color = new Color(1,0.5f,0.5f,1);

        int timer = 5;
        while (timer > 0)
        {  
            timer--;
            yield return new WaitForSeconds(0.025f);
        }

        p.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
