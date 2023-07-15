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
    [SerializeField] private float moveForce = 6f;
    [SerializeField] private float jumpForce = 10f;

    private enum playerAction { idle, run, jump, fall }

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
        rb.velocity = new Vector2(xAxis * moveForce, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        updateAnimation();
    }

    private void updateAnimation()
    {
        playerAction action;

        if (xAxis > 0)
        {
            action = playerAction.run;
            spriteR.flipX = false;
        }
        else if (xAxis < 0)
        {
            action = playerAction.run;
            spriteR.flipX = true;
        }
        else
        {
            action = playerAction.idle;
        }

        if(rb.velocity.y > .1f) 
        { 
            action = playerAction.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            action = playerAction.fall;
        }

        animation.SetInteger("action", (int)action);
    }
}
