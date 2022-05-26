using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.2f;
    public float jumpSpeed = 1.2f;
    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if( Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
            spriteRenderer.flipX = false;
            animator.Play("PlayerRun");
       }
       else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
           
            spriteRenderer.flipX = true;
            animator.Play("PlayerRun");
        }
       else if(Input.GetKey(KeyCode.Space)|| Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            animator.Play("Jump");
        }
        else
        {
            animator.Play("idle");
        }
    }
}
