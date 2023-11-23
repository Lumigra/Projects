using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnObjectCarried : UnityEvent<GameObject> { }
public class PlayerInteraction : MonoBehaviour
{
    [HideInInspector] public OnObjectCarried objectCarried = new OnObjectCarried();

    public KeyCode InteractKey;
    public GameObject PickedUpObj;
    public SpriteRenderer sRenderer;

    [HideInInspector] public bool CanInteract;

    public GameObject interactable { get; private set; }
    private Player player;
    private void Start()
    {
        sRenderer.enabled = false;
        CanInteract = false;
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(InteractKey))
        {
            if (player.PlayerStatus.isTalking)
            {
                player.dialogue.NextDialogue();
                return;
            }

            if (interactable != null)
            {
                interactable.GetComponent<IInteractable>().Interact(this);
                objectCarried.Invoke(PickedUpObj);
            }

            else
            {
                //Check if any object is held
                if (PickedUpObj != null) PickedUpObj.GetComponent<IInteractable>().Interact(this);
                objectCarried.Invoke(PickedUpObj);
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (interactable != null) return;
        if (interactable == collision) return;
        if (collision.GetComponent<IInteractable>() != null)
        {
            interactable = collision.gameObject;
            sRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable = null;
        sRenderer.enabled = false;
    }

    public void SwapItem(IPickupable otherItem)
    {
        PickedUpObj.GetComponent<IPickupable>().Drop(this);
        otherItem.Pickup(this);
    }
}
