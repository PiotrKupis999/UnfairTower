using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartingScript : MonoBehaviour
{
    public GameObject Player;
    float desiredDuration = 3f;
    float elapsedTime = 0;
    public static Vector3 playerEndPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BrokerScript.fall)
        {
            Vector3 endPosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 2f, playerEndPosition.z);

            float percentageComplete = elapsedTime / desiredDuration;
            Player.transform.position = Vector3.Lerp(playerEndPosition, endPosition, percentageComplete);
            elapsedTime += Time.deltaTime;


        }
        else
        {
            elapsedTime = 0;
        }


    }
}
