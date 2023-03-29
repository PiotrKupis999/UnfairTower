using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPointScript : MonoBehaviour
{

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
        else
        {
            GetComponent<Collider2D>().isTrigger = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameControllerScript.level++;
            Debug.Log("+1");
            Destroy(this.gameObject);
        }
        
    }
}
