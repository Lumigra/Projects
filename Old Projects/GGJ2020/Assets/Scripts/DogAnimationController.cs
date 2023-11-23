using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimationController : MonoBehaviour
{

    Animator anim => GetComponent<Animator>();
    Dog dog => GetComponent<Dog>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 normalizedDir = Vector3.Normalize(GetDirection());

        float upMove = Mathf.Abs(normalizedDir.y);
        float sideMove = Mathf.Abs(normalizedDir.x);

        if (upMove > sideMove)
        {
            if (normalizedDir.y > 0)
            {
                anim.SetBool("isMovingUpwards", true);
                anim.SetBool("isMovingDownwards", false);
                anim.SetBool("isMovingSidewards", false);

            }
            else
            {
                anim.SetBool("isMovingUpwards", false);
                anim.SetBool("isMovingDownwards", true);
                anim.SetBool("isMovingSidewards", false);
            }
        }
        else
        {
            anim.SetBool("isMovingUpwards", false);
            anim.SetBool("isMovingDownwards", false);
            anim.SetBool("isMovingSidewards", true);
        }
    }

    Vector2 GetDirection()
    {
        return dog.target.transform.position - transform.position;
    }
}
