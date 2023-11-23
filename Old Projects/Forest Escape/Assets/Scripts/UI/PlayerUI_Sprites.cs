using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI_Sprites : MonoBehaviour
{
    public List<Image> HPSprites = new List<Image>();
    public List<Image> Arrows = new List<Image>();

    public GameObject Player;

    private void Start()
    {
        Player player = Player.GetComponent<Player>();

        for(int x = 0; x < Arrows.Count; x++)
        {
            if (player.GetComponent<PlayerShoot>().GetAmmo() == 0)
            {
                Arrows[x].gameObject.SetActive(false);
                continue;
            }

            if (player.GetComponent<PlayerShoot>().GetAmmo() >= x) Arrows[x].gameObject.SetActive(true);
            else Arrows[x].gameObject.SetActive(false);
        }

        player.GetComponent<Health>().onHealthChanged.AddListener(ChangeHPSprites);
        player.GetComponent<PlayerShoot>().AmmoChanged.AddListener(ChangeArrowCount);
    }

    void ChangeHPSprites(int hp)
    {
        for (int x = 0; x < HPSprites.Count; x++)
        {
            if (hp == 0)
            {
                HPSprites[x].gameObject.SetActive(false);
                continue;
            }

            if (x < hp) HPSprites[x].gameObject.SetActive(true);
            else HPSprites[x].gameObject.SetActive(false);
        }
    }

    void ChangeArrowCount(int ammo)
    {
        for (int x = 0; x < Arrows.Count; x++)
        {
            if (ammo == 0)
            {
                Arrows[x].gameObject.SetActive(false);
                continue;
            }

            if (x < ammo) Arrows[x].gameObject.SetActive(true);
            else Arrows[x].gameObject.SetActive(false);
        }
    }
}
