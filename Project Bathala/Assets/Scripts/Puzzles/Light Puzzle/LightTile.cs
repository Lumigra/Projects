using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsActivated : UnityEvent<bool> { }
public class LightTile : MonoBehaviour
{
    [HideInInspector] public IsActivated activated = new IsActivated();

    //Sprites used for various states
    public Sprite DeactivatedTile;
    public Sprite ActivatedTile;
    public Sprite LitTile;

    public bool IsCorrect;

    public bool IsActivated { get; private set; }
    public bool IsSteppedOn { get; private set; }

    private SpriteRenderer sRenderer;
    private BoxCollider2D col2D;
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        sRenderer.sprite = DeactivatedTile;
        col2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //If Correct Tiles has been stepped on, don't check again
        if (IsSteppedOn) return;
        //If puzzle hasn't been activated don't trigger
        if (IsActivated)
        {
            if (collision.GetComponent<Player>() && IsCorrect)
            {
                IsSteppedOn = true;
                sRenderer.sprite = LitTile;
            }
        }
        activated.Invoke(IsCorrect);
    }

    public IEnumerator FlashTile(float flashTime)
    {
        sRenderer.sprite = LitTile;
        yield return new WaitForSeconds(flashTime);
        if(!IsSteppedOn) sRenderer.sprite = ActivatedTile;
    }

    public void ResetTile()
    {
        sRenderer.sprite = ActivatedTile;
        IsSteppedOn = false;
    }

    public void ActivateTile()
    {
        sRenderer.sprite = ActivatedTile;
        IsActivated = true;
    }

    public void DeactivateTile()
    {
        sRenderer.sprite = DeactivatedTile;
        col2D.isTrigger = false;
    }
}
