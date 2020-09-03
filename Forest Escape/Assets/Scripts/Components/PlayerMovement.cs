using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Tooltip("0 for left, 1 for right")]
    public Lanes Lanes;

    public float speed { get; private set; }
    private int LaneNo;
    private bool hasMoved;
    private TestTouch testTouch;
    //private Touch touch;
    private void Start()
    {
        speed = GameScene.gameScene.SpawnerData.CurrentSet.PlayerSpeed;
        GameScene.gameScene.dataUpdated.AddListener(UpdateSpeed);
        hasMoved = false;
        testTouch = GetComponent<TestTouch>();
        LaneNo = 2;
        ChangeLane();
    }

    void Update () {
        Vector3 newPos = transform.position;
        newPos.x += (speed * Time.deltaTime);
        transform.position = newPos;

#if UNITY_IOS || UNITY_ANDROID
        //Debug.Log("android");
        if(testTouch.touchPhase == TouchPhase.Moved)
        {
            if (hasMoved) return;
            LaneNo = GetNewLaneNo();
            ChangeLane();
            hasMoved = true;
        }
        if(testTouch.touchPhase == TouchPhase.Ended)
        {
            hasMoved = false;
        } 
#else
        if (testTouch.mouseState == TestTouch.MouseStates.MouseMoved)
        {
            if (hasMoved) return;
            LaneNo = GetNewLaneNo();
            ChangeLane();
            hasMoved = true;
        }
        if(testTouch.mouseState == TestTouch.MouseStates.MouseEnded)
        {
            hasMoved = false;
        }
#endif
    }

    int GetNewLaneNo()
    {
        int newLaneNo = LaneNo;
#if UNITY_IOS || UNITY_ANDROID
        Debug.Log(testTouch.GetTouchPosDifference());
        if (testTouch.GetTouchPosDifference().y > 0)
        {
            newLaneNo--;
            if (newLaneNo < 1) return 1;
            return newLaneNo;
        }
        if (testTouch.GetTouchPosDifference().y < 0)
        {
            newLaneNo++;
            if (newLaneNo > Lanes.GetLaneCount()) return Lanes.GetLaneCount();
            return newLaneNo;
        }
#else
        if (testTouch.GetMousePosDifference().y > 0)
        {
            newLaneNo--;
            if (newLaneNo < 1) return 1;
            return newLaneNo;
        }
        if (testTouch.GetMousePosDifference().y < 0)
        {
            newLaneNo++;
            if (newLaneNo > Lanes.GetLaneCount()) return Lanes.GetLaneCount();
            return newLaneNo;
        }
#endif
        return newLaneNo;
    }

    void ChangeLane()
    {
        Vector3 newPos = transform.position;
        newPos.y = Lanes.GetLane(LaneNo).transform.position.y;
        SpriteOrderSetter orderSetter = new SpriteOrderSetter(GetComponent<SpriteRenderer>(), GetLaneNo());
        transform.position = newPos;
    }

    public int GetLaneNo()
    {
        return LaneNo;
    }

    void UpdateSpeed()
    {
        speed = GameScene.gameScene.SpawnerData.CurrentSet.PlayerSpeed;
    }

    void InputTouch()
    {
        int touches = Input.touchCount;

        if (touches > 0)
        {
            for (int i = 0; i < touches; i++)
            {
                Touch touch = Input.GetTouch(i);

                TouchPhase phase = touch.phase;

                switch (phase)
                {
                    case TouchPhase.Began:
                        break;
                    case TouchPhase.Moved:
                        break;
                    case TouchPhase.Stationary:
                        break;
                    case TouchPhase.Ended:
                        break;
                    case TouchPhase.Canceled:
                        break;
                }
            }
        }
    }
}
