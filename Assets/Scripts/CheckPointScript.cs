using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public static bool make_steps = false;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = cam.transform.position.y + 5.50f;

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Step"))
        {
            make_steps = true;
        }
    }
}
