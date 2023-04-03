using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrokerScript : MonoBehaviour
{
    public static bool fall;

    // Start is called before the first frame update
    void Start()
    {
        fall = false;
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
            GameControllerScript.is_moving = false;


            PlayerPrefs.SetInt("best_score", GameControllerScript.best_score);

            //GameControllerScript.level = 0;
            //SceneManager.LoadScene(0);

            collision.gameObject.transform.position = new Vector3(0, Camera.main.transform.position.y + 2f, transform.position.z);


            fall = true;


        }
        else
        {
            Destroy(collision.gameObject);

        }


    }
}
