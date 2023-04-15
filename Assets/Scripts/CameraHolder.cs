using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{

    public GameObject player;
    public static float camera_speed = 1;

    void Update()
    {
        //camera's movement

        float y = player.transform.position.y;

        if (y > transform.position.y + 2.5f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, y, transform.position.z), Time.deltaTime*2);
        }
        else if (GameControllerScript.is_moving)
        {
            transform.position += Vector3.up * camera_speed * Time.deltaTime;
        }

    }
}
