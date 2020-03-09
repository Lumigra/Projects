using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Repair : MonoBehaviour
{
    public bool IsHammer;
    public bool IsRag;
    public bool IsBag;
    public bool IsHand;
    public bool IsTape;
    public bool IsGlue;

    public Button hand;
    public Button broom;
    public Button mop;
    public Button tape;
    public Button sew;
    public Button glue;

    public static Repair Instance;
    public Canvas Pause;

    GameObject myEventSystem;
    void Start()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
        Pause.enabled = false;
        DisableAllModes();
        myEventSystem = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Hand();
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            Bag();
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            Rag();
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            Tape();
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            Hammer();
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            Glue();
    }

    public void Hammer()
    {
        IsHammer = true; 
        IsRag = false;
        IsBag = false;
        IsHand = false;
        IsTape = false;
        IsGlue = false;
    myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(sew.gameObject);

    }
    public void Tape()
    {
        IsHammer = false;
        IsRag = false;
        IsBag = false;
        IsHand = false;
        IsTape = true;
        IsGlue = false;
        //tape.targetGraphic.color = tape.colors.selectedColor;
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(tape.gameObject);

    }
    public void Rag()
    {
        IsHammer = false;
        IsRag = true;
        IsBag = false;
        IsHand = false;
        IsTape = false;
        IsGlue = false;
        //mop.targetGraphic.color = mop.colors.selectedColor;
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(mop.gameObject);

    }
    public void Glue()
    {
        IsHammer = false;
        IsRag = false;
        IsBag = false;
        IsHand = false;
        IsTape = false;
        IsGlue = true;
        //glue.targetGraphic.color = glue.colors.selectedColor;
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(glue.gameObject);

    }
    public void Hand()
    {
        IsHammer = false;
        IsRag = false;
        IsBag = false;
        IsHand = true;
        IsTape = false;
        IsGlue = false;
        //hand.targetGraphic.color = hand.colors.selectedColor;
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(hand.gameObject);

    }
    public void Bag()
    {
        IsHammer = false;
        IsRag = false;
        IsBag = true;
        IsHand = false;
        IsTape = false;
        IsGlue = false;
        //broom.targetGraphic.color = broom.colors.selectedColor;
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(broom.gameObject);

    }
    public void OnPause()
    {
        Pause.enabled = true;
        Time.timeScale = 0;
    }
    public void resume()
    {
        Time.timeScale = 1;
        Pause.enabled = false;
    }

    public void DisableAllModes()
    {
        IsHammer = false;
        IsBag = false;
        IsRag = false;
        IsHand = false;
        IsGlue = false;
        IsTape = false;
    }
}
