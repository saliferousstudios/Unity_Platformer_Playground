using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumEnemy : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Collider2D collider;
    [SerializeField]
    private Collider2D leftTarget;
    [SerializeField]
    private Collider2D rightTarget;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Animator animator;    
    private SpriteRenderer spriteRenderer;
    bool goingRight = false;
    int direction = -1;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == leftTarget || collision == rightTarget)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            direction = direction * -1;
        }
        
    }
    // Update is called once per frame


    void Update()
    {
       
            rigidbody.velocity = new Vector2(speed * direction, rigidbody.velocity.y);

        
       /* if (transform.position.x >= leftTarget.position.x)
        {
            spriteRenderer.flipX = false;
            rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
        }
        else if (transform.position.x <= rightTarget.position.x)
        {
             rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            spriteRenderer.flipX = true;
        }*/
        /* if(transform.position.x < player.position.x)
         {
             spriteRenderer.flipX = true;
         }
         else if (transform.position.x < player.position.x)
         {
             spriteRenderer.flipX = false;
         }*/
    }
}
