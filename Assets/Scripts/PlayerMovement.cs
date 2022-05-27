using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.2f;
    [SerializeField] private float jumpSpeed = 1.2f;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Collider2D colider;
   [SerializeField] private LayerMask ground;
   [SerializeField] private LayerMask enemies;
    [SerializeField] private int cherries = 0;
  [SerializeField] private Text cherriesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "cherry")
        {
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = cherries.ToString();
        }
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colider = GetComponent<Collider2D>();

    }
    bool isRunning = false;
    bool canDoubleJump = true;
    // Update is called once per frame
    void Update()
    {
        canDoubleJump = true;
        if (colider.IsTouchingLayers(enemies))
        {
            animator.Play("hurt");
        }
        if (colider.IsTouchingLayers(ground))
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow))
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
            else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && colider.IsTouchingLayers(ground))
            {
                animator.Play("crouch");
                rigidBody.velocity = new Vector2(0, 0);
            }
            else if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && colider.IsTouchingLayers(ground))
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
                animator.Play("jump");
            }
            else
            {
                animator.Play("idle");
            }
                
            
         }
        else
        {
            
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, -jumpSpeed * 2);
                animator.Play("crouch");
            }
            else if (rigidBody.velocity.y < 0)
            {
                animator.Play("fall");
                if (canDoubleJump && (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && colider.IsTouchingLayers(ground))
                {
                    canDoubleJump = false;
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
                    animator.Play("jump");
                }
            }
        }
        /*

        
       else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
           
            spriteRenderer.flipX = true;animator.Play("run");
           // if(colider.IsTouchingLayers(ground) && !isRunning)
           // {  isRunning = true; }
           
        }
        else if(Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            isRunning = false;
        }
       
      
       
        else if (colider.IsTouchingLayers(ground))
        {
            animator.Play("idle");

        }
        
        else if (rigidBody.velocity.y > 0)
        {
            animator.Play("jump");
        }
      
        else
        {
            animator.Play("idle");
        }*/
    }
}
