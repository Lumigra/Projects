using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed = 2.0f;
    private Vector3 dragOrgin;
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetPosition();
        //if(!Input.GetMouseButtonDown(0))
        //{
            
        //    return;
        //}
        //Debug.Log("HI");

        //if (Input.GetMouseButtonDown(0))
        //{
        //    dragOrgin = Input.mousePosition;
        //    return;
        //}

        if(Input.GetMouseButtonDown(0))
        {
            dragOrgin = Input.mousePosition;
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrgin);
            Vector3 move = new Vector3(pos.x * dragSpeed, pos.y* dragSpeed, pos.z * dragSpeed);

            transform.Translate(move, Space.World);
        }



    }

    public void ResetPosition()
    {
        Vector3 origPos = Vector3.zero;
        origPos.z = -10;

        transform.position = origPos;
    }
}
