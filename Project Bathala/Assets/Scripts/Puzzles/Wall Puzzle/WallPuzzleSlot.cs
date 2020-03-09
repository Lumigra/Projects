using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallPuzzleSlot : MonoBehaviour, IInteractable 
{
    [HideInInspector] public bool isCorrect = false;
    public DroppableTile CorrectTile;

    private WallPuzzle puzzle;
    [SerializeField] private DroppableTile insertedTile;

    public void Interact(PlayerInteraction player)
    {
        if (insertedTile == null)
        {
            if (player.PickedUpObj == null) return;
            if (player.PickedUpObj.GetComponent<DroppableTile>() == null) return;
            InsertTile(player);
        }
        else
        {
            if(player.PickedUpObj == null)
            {
                RemoveTile(player);
            }
            else
            {
                SwapTile(player);
            }
        }
    }

    void InsertTile(PlayerInteraction player)
    {
        insertedTile = player.PickedUpObj.GetComponent<DroppableTile>();
        insertedTile.transform.position = transform.position;
        insertedTile.gameObject.SetActive(true);
        insertedTile.gameObject.GetComponent<Collider2D>().enabled = false;
        player.PickedUpObj = null;

        CheckTile();
    }

    void RemoveTile(PlayerInteraction player)
    {
        insertedTile.GetComponent<Collider2D>().enabled = true;
        player.PickedUpObj = insertedTile.gameObject;
        insertedTile.gameObject.SetActive(false);
        insertedTile = null;
        CheckTile();
    }

    void SwapTile(PlayerInteraction player)
    {
        //DroppableTile tileToSwap = player.PickedUpObj.GetComponent<DroppableTile>();
        //if (tileToSwap == null) return;

        //player.PickedUpObj = insertedTile.gameObject;
        //insertedTile.gameObject.SetActive(false);

        //player.PickedUpObj = insertedTile.gameObject;
        //insertedTile.transform.position = transform.position;
        //insertedTile.transform.parent = transform;
        //insertedTile.gameObject.SetActive(true);

        //insertedTile = tileToSwap;

        DroppableTile tileToSwap = insertedTile;
        player.PickedUpObj.SetActive(true);
        insertedTile = player.PickedUpObj.GetComponent<DroppableTile>();
        insertedTile.transform.position = transform.position;
        insertedTile.GetComponent<Collider2D>().enabled = false;

        player.PickedUpObj = tileToSwap.gameObject;
        player.PickedUpObj.GetComponent<Collider2D>().enabled = true;
        player.PickedUpObj.SetActive(false);

        CheckTile();
    }

    void CheckTile()
    {
        if (insertedTile == null) { isCorrect = false; return; }
        if(insertedTile != CorrectTile) { isCorrect = false; return; }
        isCorrect = true; return;
    }
}
