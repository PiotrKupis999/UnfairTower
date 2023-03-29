using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEditor.SearchService;
using UnityEngine;

public class StepSpawnerScript : MonoBehaviour
{
    public float max_time;
    public GameObject step;
    public GameObject stepPoint;
    public GameObject background;

    public float range;
    public float min_length;
    public float max_length;

    private int step_count;

    // Start is called before the first frame update
    void Start()
    {
        step_count = 8;
    }



    // Update is called once per frame
    void Update()
    {
        float y = Camera.main.transform.position.y + 6f;

        transform.position = new Vector3(transform.position.x, y, transform.position.z);


        if (CheckPointScript.make_steps)
        {
            
            GameObject new_stepPoint = Instantiate(stepPoint);
            new_stepPoint.transform.position = transform.position + new Vector3(0, 0.3f, 0);


            GameObject new_step = Instantiate(step);
            new_step.transform.position = transform.position + new Vector3(Random.Range(-range, range), 0, 0);
            new_step.transform.localScale = new Vector3(Random.Range(min_length, max_length), new_step.transform.localScale.y, new_step.transform.localScale.z);

            step_count++;

            if (step_count % 10 == 0)
            {
                new_step.transform.position = transform.position;
                new_step.transform.localScale = new Vector3(5.80f, new_step.transform.localScale.y, new_step.transform.localScale.z);
                new_step.GetComponent<SpriteRenderer>().color = Color.green;
            }


            CheckPointScript.make_steps = false;
        }



    }


}
