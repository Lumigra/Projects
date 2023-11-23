using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogue : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text text;
    public Image DialogueImage;
    private Dialogues npc;

    private void Start()
    {
        DialogueBox.SetActive(false);
    }

    public void StartConversation(Dialogues npc, string dialogueTree, Sprite image)
    {
        DialogueBox.SetActive(true);
        this.npc = npc;
        this.npc.SetTree(dialogueTree);
        text.text = npc.GetCurrentDialogue();

        if (image != null)
        {
            DialogueImage.gameObject.SetActive(true);
            DialogueImage.sprite = image;
        }
        else DialogueImage.gameObject.SetActive(false);

        PlayerStatus pStatus = GetComponent<Player>().PlayerStatus;
        pStatus.CanWalk = false;
        pStatus.canInteract = false;
        pStatus.isTalking = true;
        //pStatus.isInteracting = 
    }

    public void NextDialogue()
    {
        if(npc.End())
        {
            DialogueBox.SetActive(false);
            npc = null;

            PlayerStatus pStatus = GetComponent<Player>().PlayerStatus;
            pStatus.CanWalk = true;
            pStatus.canInteract = true;
            pStatus.isTalking = false;

            return;
        }
        npc.Next();
        text.text = npc.GetCurrentDialogue();
    }
}
