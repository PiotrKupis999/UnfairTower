using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class StepSpawnerScript : MonoBehaviour
{
    public float max_time;
    private Queue<GameObject> queue = new Queue<GameObject>(); 
    public GameObject step;
    public GameObject background;

    public float range;
    public float min_length;
    public float max_length;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        float y = Camera.main.transform.position.y + 6f;

        transform.position = new Vector3(transform.position.x, y, transform.position.z);


        if (CheckPointScript.make_steps)
        {
            GameObject new_step = Instantiate(step);
            new_step.transform.localScale = new Vector3(Random.Range(min_length, max_length), new_step.transform.localScale.y, new_step.transform.localScale.z);
            new_step.transform.position = transform.position + new Vector3(Random.Range(-range, range), 0, 0);

            CheckPointScript.make_steps = false;
        }



    }


}
