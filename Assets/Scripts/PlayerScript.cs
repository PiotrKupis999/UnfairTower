using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb;
    private Collider2D coll;
    private int x_jump = 3;


    private bool jumpable = true;

    [SerializeField]
    public float speed;
    public float slow_down;
    public float jump_force;
    public float jump_force2;
    



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

    }

    private void FixedUpdate()
    {
        

    }



    // Update is called once per frame
    void Update()
    {
        


        if (Input.touchCount >= 1)
        {
            

            float touchPos = Input.GetTouch(0).position.x;
            
            //float touchPos1 = Input.GetTouch(1).position.x;

            if (touchPos < 585)
            {

                rb.AddForce(Vector2.left * Time.deltaTime * speed);
                
                if(rb.velocity.x > 0)
                {
                    rb.AddForce(Vector2.left * Time.deltaTime * speed * 2);
                }


            }
            else if (touchPos >= 585 )
            {
                rb.AddForce(Vector2.right * Time.deltaTime * speed);

                if (rb.velocity.x < 0)
                {
                    rb.AddForce(Vector2.right * Time.deltaTime * speed * 2);
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x / slow_down, rb.velocity.y);
        }




        if (rb.velocity.y > 0)
        {

            coll.isTrigger = true;
        }
        else coll.isTrigger = false;

        if (rb.IsTouchingLayers() && jumpable && Input.touchCount == 2)
        {
            Jump();
        }

        if (!GameControllerScript.is_moving)
        {

        }
        


    }

  
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Step"))
        {
            collision.isTrigger = true;
            jumpable = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Step"))
        {
            collision.isTrigger = false;
            jumpable = true;
        }

    }


    private void Jump()
    {

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

        
        //jumpable = false;

        
        
        



    }
}
