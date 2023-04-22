using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartingScript : MonoBehaviour
{
    public GameObject Player;
    float desiredDuration = 1f;
    float elapsedTime = 0;
    public static Vector3 playerEndPosition;


    void Update()
    {
        if (BrokerScript.fall) //returning player to the restart position
        {
            Vector3 endPosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 2f, playerEndPosition.z);
            float percentageComplete = elapsedTime / desiredDuration;
            Player.transform.position = Vector3.Lerp(playerEndPosition, endPosition, percentageComplete);
            elapsedTime += Time.deltaTime;
            Player.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            Player.GetComponent<Rigidbody2D>().rotation = 0f;
        }
        else
        {
            elapsedTime = 0;
        }
    }
}
