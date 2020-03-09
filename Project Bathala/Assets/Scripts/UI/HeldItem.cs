using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeldItem : MonoBehaviour
{
    public Image HeldItemImage;
    public Player player;

    private void Start()
    {
        player.GetComponent<PlayerInteraction>().objectCarried.AddListener(DisplayObject);
        HeldItemImage.gameObject.SetActive(false);
    }

    void DisplayObject(GameObject obj)
    {
        Debug.Log("Display image");
        if(obj != null)
        {
            HeldItemImage.gameObject.SetActive(true);
            HeldItemImage.sprite = obj.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            HeldItemImage.gameObject.SetActive(false);
        }
    }
}
