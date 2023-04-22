using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    enum WallSide
    {
        Left,
        Right
    }

    [SerializeField] WallSide wallSide;
    float waiting = 1f;
    bool waiting2 = true;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y + 7, transform.position.z);
        waiting += Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //stop game and save best score
        if (collision.CompareTag("Player") && waiting >= 1f)
        {
            Debug.Log("eeloo");
            collision.transform.position = new Vector3(-collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
            waiting += Time.deltaTime;
            PlayerScript.jumpable = false;
            /*
            switch (wallSide)
            {
                case WallSide.Left:
                    collision.transform.position = new Vector3(-this.transform.position.x, collision.transform.position.y, collision.transform.position.z);
                    break;
                case WallSide.Right:
                    break;

            }
            
            GameControllerScript.is_moving = false;

            PlayerPrefs.SetInt("best_score", GameControllerScript.best_score);
            PlayerPrefs.Save();

            RestartingScript.playerEndPosition = collision.gameObject.transform.position;
            */
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //be touchable while not toughing steps
        {
            
            PlayerScript.jumpable = true;
        }

    }



    
}
