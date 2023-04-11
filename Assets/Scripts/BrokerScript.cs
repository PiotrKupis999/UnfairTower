using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

            RestartingScript.playerEndPosition = collision.gameObject.transform.position;
            //GameControllerScript.level = 0;
            //SceneManager.LoadScene(0);

            /*
            float desiredDuration = 10f;
            float elapsedTime = 0;
            Vector3 startPosition = collision.gameObject.transform.position;
            Vector3 endPosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 2f, startPosition.z);
            while (desiredDuration>elapsedTime)
            {
                float percentageComplete = elapsedTime/desiredDuration;
                collision.gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
                elapsedTime += Time.deltaTime;
                Debug.Log(elapsedTime);
            }
            */

            

            fall = true;


        }
        else
        {
            Destroy(collision.gameObject);

        }


    }
}
