using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StepScript : MonoBehaviour
{
    public float step_speed;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControllerScript.is_moving)
        {
            //transform.position += Vector3.down * step_speed * Time.deltaTime;
        }
    }

    

}
