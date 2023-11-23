using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTouch : MonoBehaviour
{
    public enum MouseStates
    {
        MouseBegan,
        MouseMoved,
        MouseStationary,
        MouseEnded,
        MouseCanceled,
        MouseDefault
    }

    public float Offset;
    private int laneNo;
    private bool hasMoved;
    private Vector3 oldMousePosition = Vector3.zero;
    private Vector3 newMousePosition = Vector3.zero;

    private Touch oldTouchPosition;
    private Touch newTouchPosition;
    public MouseStates mouseState { get; private set; }
    public TouchPhase touchPhase { get; private set; }
    void Start()
    {
        touchPhase = TouchPhase.Canceled;
        mouseState = MouseStates.MouseDefault;
        laneNo = 2;
        //transform.position = lanes.GetLane(laneNo).transform.position;
        hasMoved = false;
    }

    void Update()
    {

#if UNITY_IOS || UNITY_ANDROID
        InputTouch();
#else
        InputMouse();
#endif
        //if(GetMouseState() == MouseStates.MouseMoved)
        //{
        //    if (hasMoved) return;
        //    laneNo = GetNewLaneNo();
        //    ChangeLane();
        //    //hasMoved = true;
        //}
    }

    void InputTouch()
    {
        if (Input.touchCount == 0)
        {
            touchPhase = TouchPhase.Canceled;
            return;
        }
        Touch touch = Input.GetTouch(0);
        switch (touch.phase)
        {
            case TouchPhase.Began:
                if (oldTouchPosition.fingerId != touch.fingerId) return;

                touchPhase = TouchPhase.Began;

                oldTouchPosition = touch;
                newTouchPosition = touch;
                //Debug.Log("Old touch: " + oldTouchPosition.position);
                //Debug.Log("New touch: " + newTouchPosition.position);
                break;
            case TouchPhase.Ended:
                touchPhase = TouchPhase.Ended;
                hasMoved = false;
                oldTouchPosition = default(Touch);
                break;
            case TouchPhase.Moved:
                touchPhase = TouchPhase.Moved;
                newTouchPosition = touch;
                //Debug.Log(GetTouchPosDifference());
                //Debug.Log("Moved Touch: " + newTouchPosition.position);
                break;
        }

        //Debug.Log(touch.phase);
    }

    void InputMouse()
    {
        mouseState = MouseStates.MouseDefault;
            mouseState = GetMouseState();
        //Input.mousePosition;
        if(Input.GetMouseButton(0))
        {
            switch(mouseState)
            {
                case MouseStates.MouseBegan:
                    break;
                case MouseStates.MouseMoved:
                    break;
                case MouseStates.MouseStationary:
                    break;
                case MouseStates.MouseCanceled:
                    break;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            hasMoved = false;
        }
    }

    //Mouse state changer and checker
    MouseStates GetMouseState()
    {
        MouseStates state = MouseStates.MouseDefault;
        if (Input.GetMouseButton(0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                state = MouseStates.MouseBegan;
                //sets oldMousePosition to the mouse's position
                oldMousePosition = Input.mousePosition;
                //defaults new position to the old position to avoid glitches
                newMousePosition = oldMousePosition;
                return state;
            }
            newMousePosition = Input.mousePosition;

            //if distance between the new position and the old position is less than the offset value, stay stationary
            if (Vector3.Distance(newMousePosition, oldMousePosition) <= Offset)
            {
                state = MouseStates.MouseStationary;
                return state;
            }
            //if distance between the new position and the old position is greater than the offset value, switch to moved
            if (Vector3.Distance(newMousePosition, oldMousePosition) > Offset)
            {
                state = MouseStates.MouseMoved;
                return state;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
           state = MouseStates.MouseEnded;
            return state;
        }
        return state;
    }

    public Vector3 GetMousePosDifference()
    {
        //converts the old and new position to screen coordinates, then subtracts the old pos from the new pos
        return Camera.main.ScreenToWorldPoint(newMousePosition) - Camera.main.ScreenToWorldPoint(oldMousePosition);
    }

    public Vector3 GetTouchPosDifference()
    {
        return newTouchPosition.position - oldTouchPosition.position;
    }
}
