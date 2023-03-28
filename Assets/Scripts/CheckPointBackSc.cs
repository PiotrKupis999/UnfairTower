using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBackSc : MonoBehaviour
{
    public static bool make_back = false;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float y = cam.transform.position.y - 12f;

        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        make_back = true;
        Debug.Log("HALOO");
    }
}
