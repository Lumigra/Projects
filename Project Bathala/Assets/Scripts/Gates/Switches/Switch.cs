using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnActivated : UnityEvent<bool> { }
public class Switch : MonoBehaviour
{
    [HideInInspector] public OnActivated activated = new OnActivated();

    public Sprite ActiveState;
    public Sprite InactiveState;

    protected SpriteRenderer sRenderer;

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Activate()
    {

    }
}
