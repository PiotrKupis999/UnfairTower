using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrokerScript : MonoBehaviour
{

    public static int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = Camera.main.transform.position.y - 6.2f;

        transform.position = new Vector3(transform.position.x, y, transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
            GameControllerScript.is_moving = false;
            level = 0;
        }
        else
        {
            Destroy(collision.gameObject);
            level++;

        }


    }
}
