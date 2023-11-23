using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{

    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    SpriteRenderer renderer => GetComponent<SpriteRenderer>();

    Vector2 oldPos = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oldPos == Vector2.zero)
            oldPos = transform.position;

        float direction = oldPos.x - transform.position.x;

        if (direction > 0)
            renderer.flipX = false;
        else
            renderer.flipX = true;

        oldPos = transform.position;

        //if (rb.velocity.x < 0)
        //    renderer.flipX = false;
        //else if(rb.velocity.x > 0)
        //    renderer.flipX = true;
    }
}
