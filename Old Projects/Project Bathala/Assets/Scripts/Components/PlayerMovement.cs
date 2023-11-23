using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Player>().PlayerStatus.CanWalk)
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            float yInput = Input.GetAxisRaw("Vertical");

            Vector3 newMove = new Vector2(xInput, yInput) * Speed * Time.deltaTime;

            transform.position += newMove;
        }
    }
}
