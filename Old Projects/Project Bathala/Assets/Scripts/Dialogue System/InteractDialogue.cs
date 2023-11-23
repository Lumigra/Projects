using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialogue : MonoBehaviour, IInteractable
{
    public string DialogueTree;
    public Sprite DialogueImage;
    private Dialogues dialogues;

    void Start()
    {
        dialogues = GetComponent<Dialogues>();
    }

    public void Interact(PlayerInteraction player)
    {
        dialogues.Reset();
        Player Player = player.GetComponent<Player>();
        Player.dialogue.StartConversation(dialogues, DialogueTree, DialogueImage);
    }


}
