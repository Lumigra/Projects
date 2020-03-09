using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDialSpun : UnityEvent { }
public class OnDialChange : UnityEvent<int> { }
public class Dial : MonoBehaviour
{
    [HideInInspector] public OnDialSpun dialSpun = new OnDialSpun();
    [HideInInspector] public OnDialChange dialChange = new OnDialChange();

    [HideInInspector] public SpriteRenderer Renderer;

    public int DialNumber;
    public int MaximumPositions;
    public int InitialPosition;

    private bool IsActive;
    
    public int Position { get; private set; }

    //private SpriteRenderer renderer;
    void Start()
    {
        if (InitialPosition <= 0 || InitialPosition > MaximumPositions) throw new UnityException("Invalid Initial State");
        Position = InitialPosition;

        Renderer = GetComponent<SpriteRenderer>();

        Quaternion rotation = Quaternion.Euler(0, 0, -((360 / MaximumPositions) * (Position - 1)));
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsActive) return;
        #region DialSpinning
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Rotate(-1);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Rotate(1);
        #endregion

        #region DialChanging
        if (Input.GetKeyDown(KeyCode.UpArrow)) ChangeDial(1);
        if (Input.GetKeyDown(KeyCode.DownArrow)) ChangeDial(-1);
        #endregion
    }

    public void SetActive(bool ActiveState)
    {
        IsActive = ActiveState;
    }

    void Rotate(int value)
    {
        Position += value;
        if (Position < 1) Position = MaximumPositions;
        if (Position > MaximumPositions) Position = 1;

        Quaternion rotation = Quaternion.Euler(0, 0, -((360 / MaximumPositions) * (Position - 1)));
        transform.rotation = rotation;

        dialSpun.Invoke();
    }

    void ChangeDial(int value)
    {
        dialChange.Invoke(value);
    }
}
