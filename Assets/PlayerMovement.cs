using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animation;
    private SpriteRenderer spriteR;

    private float xAxis = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xAxis * 6f, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }

        updateAnimation();
    }

    private void updateAnimation()
    {
        if (xAxis > 0)
        {
            animation.SetBool("running", true);
            spriteR.flipX = false;
        }
        else if (xAxis < 0)
        {
            animation.SetBool("running", true);
            spriteR.flipX = true;
        }
        else
        {
            animation.SetBool("running", false);
        }
    }
}
