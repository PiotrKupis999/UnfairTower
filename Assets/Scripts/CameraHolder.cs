using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{

    public GameObject player;
    public float camera_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = player.transform.position.y;
        if (y > transform.position.y + 2.5f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, y, transform.position.z), Time.deltaTime*2);
            //transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
        else if (GameControllerScript.is_moving)
        {
            transform.position += Vector3.up * camera_speed * Time.deltaTime;
        }
        


    }
}
