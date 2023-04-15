using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public float slow_down;
    public float jump_force;
    public float jump_force2;

    private Rigidbody2D rb;
    private Collider2D coll;
    private int x_jump = 3;
    private bool jumpable = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }


    void Update()
    {
        if (Input.touchCount >= 1) //player's movement
        {
            float touchPos = Input.GetTouch(0).position.x;
            if (touchPos < Display.main.systemWidth/2)
            {
                rb.AddForce(Vector2.left * Time.deltaTime * speed);
                if(rb.velocity.x > 0)
                {
                    rb.AddForce(Vector2.left * Time.deltaTime * speed * 2);
                }
            }
            else if (touchPos >= Display.main.systemWidth / 2)
            {
                rb.AddForce(Vector2.right * Time.deltaTime * speed);

                if (rb.velocity.x < 0)
                {
                    rb.AddForce(Vector2.right * Time.deltaTime * speed * 2);
                }
            }
        }
        else //stop the player while he's not moving
        {
            rb.velocity = new Vector2(rb.velocity.x / slow_down, rb.velocity.y);
        }

        if (rb.velocity.y > 0) //be untouchable while moving up
        {
            coll.isTrigger = true;
        }
        else coll.isTrigger = false;

        if (rb.IsTouchingLayers() && jumpable && Input.touchCount == 2) //jumping conditions
        {
            Jump();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Step")) //be untouchable while toughing steps
        {
            collision.isTrigger = true;
            jumpable = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Step")) //be touchable while not toughing steps
        {
            collision.isTrigger = false;
            jumpable = true;
        }

    }


    private void Jump()
    {
        //jump instuctions
        x_jump++;
        if (Mathf.Abs(rb.velocity.x) > 2)
        {
            x_jump = 0;
            rb.velocity = Vector2.up * jump_force2;
            
        }
        else if(x_jump > 3)
        {
            rb.velocity = Vector2.up * jump_force;
            rb.rotation = 0;
            return;
        } 
    }
}
