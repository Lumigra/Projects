using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnObjDestroyed : UnityEvent { }
public class InteractableObjects : MonoBehaviour
{
    public OnObjDestroyed destroyed = new OnObjDestroyed();

    public Color FixedColor;
    public Color BrokenColor;

    public GameObject ToolPopup;

    public Sprite BrokenSprite;
    public Sprite FixedSprite;

    public AudioClip ObjectBreakSFX;
    public AudioClip ObjectFixSFX;

    private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }
    private SpriteRenderer renderer { get { return GetComponent<SpriteRenderer>();} }

    public RepairLayer RepairLayer;

    public bool isBroken;
    // Start is called before the first frame update
    void Start()
    {
        RepairLayer.clicked.AddListener(OnClick);
        RepairLayer.gameObject.SetActive(false);
        ToolPopup.SetActive(false);  
    }

    void OnClick(bool isFixed)
    {
        if (!isBroken)
            return;
        if (isFixed)
        {
            isBroken = false;
            ChangeState();
        }
    }

    void ChangeState()
    {
        if (isBroken)
        {
            GetComponent<Collider2D>().enabled = false;

            ToolPopup.SetActive(true);
            RepairLayer.gameObject.SetActive(true);
            renderer.sprite = BrokenSprite;

            destroyed.Invoke();
            if (ObjectBreakSFX != null)
            {
                audioSource.clip = ObjectBreakSFX;
                audioSource.Play();
            }
        }
        else
        {
            GetComponent<Collider2D>().enabled = true;

            RepairLayer.gameObject.SetActive(false);
            renderer.sprite = FixedSprite;

            ToolPopup.SetActive(false);
            if (ObjectFixSFX != null)
            {
                audioSource.clip = ObjectFixSFX;
                audioSource.Play();
            }
            GameManager.Manager.IncreaseRepairedCount();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBroken)
            return;
        Dog dog = collision.GetComponent<Dog>();
        if (dog == null)
            return;

        if (dog.GetTarget() != this)
            return;

        isBroken = true;
        ChangeState();
    }
}
