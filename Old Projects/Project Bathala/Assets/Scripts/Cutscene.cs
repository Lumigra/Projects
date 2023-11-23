using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Cutscene : MonoBehaviour
{
    public GameObject Textbox;
    public Dialogues Dialogue;
    public Text DialogueText;
    public string DialogueName;

    public List<Sprite> Images;
    public Image Display;

    private int currentImage;
    private SceneTransition transition;

    void Start()
    {
        transition = GetComponent<SceneTransition>();

        currentImage = 0;
        Display.sprite = Images[currentImage];
        Dialogue.SetTree(DialogueName);
        DialogueText.text = Dialogue.GetCurrentDialogue();
    }

    private void Update()
    {
        if (Input.anyKeyDown) NextDialogue();
    }

    public void NextDialogue()
    {
        if(Dialogue.End())
        {
            transition.ChangeScene();
        }

        if (Dialogue.HasTrigger())
        {
            if (Dialogue.GetTrigger() == "Change Image")
            {
                currentImage++;
                Display.sprite = Images[currentImage];
            }
            if(Dialogue.GetTrigger() == "Hide Text")
            {
                Textbox.SetActive(false);
            }
            if(Dialogue.GetTrigger() == "Show Text")
            {
                Textbox.SetActive(true);
            }
        }
        Dialogue.Next();
        DialogueText.text = Dialogue.GetCurrentDialogue();
    }
}
