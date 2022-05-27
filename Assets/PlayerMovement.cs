using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.2f;
    public float jumpSpeed = 1.2f;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Collider2D colider;
    public LayerMask ground;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
            spriteRenderer.flipX = false;
            animator.Play("run");
       }
       else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
           
            spriteRenderer.flipX = true;
           animator.Play("run");
        }
       else if((Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))&& colider.IsTouchingLayers(ground))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            animator.Play("jump");
        }
        else if((Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow)) && colider.IsTouchingLayers(ground))
        {
            animator.Play("crouch");
        }
        else if (colider.IsTouchingLayers(ground))
        {
            animator.Play("idle");

        }
        else if(rigidBody.velocity.y < 0)
        {
            if(colider.IsTouchingLayers(ground))
            {
                animator.Play("idle");
            }
            else
            {
                animator.Play("fall");
            }
            
        }
        else if (rigidBody.velocity.y > 0)
        {
            animator.Play("jump");
        }
      
        else
        {
            animator.Play("idle");
        }
    }
}
