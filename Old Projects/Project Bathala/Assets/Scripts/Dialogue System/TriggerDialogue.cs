using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public string DialogueTree;
    public bool WillRepeat;
    public Sprite DialogueImage;
    private Dialogues dialogues;
    private bool willTrigger;
    // Start is called before the first frame update
    void Start()
    {
        dialogues = GetComponent<Dialogues>();
        willTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null)
        {
            if(willTrigger)
            {
                player.dialogue.StartConversation(dialogues, DialogueTree, DialogueImage);
                if(!WillRepeat) willTrigger = false;
            }
        }
    }
}
