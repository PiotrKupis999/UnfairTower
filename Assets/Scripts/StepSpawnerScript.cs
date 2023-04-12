using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.iOS.Xcode;
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

    public Material material1;
    public Material material2;
    public Material material3;
    public Material material4;
    public Material material5;
    public Material material6;
    public Material material7;
    public Material material8;

    private int step_count;
    private int material_number = 0;
    private Material current_material;



    private Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        step_count = 8;
        materials = new Material[] { material1, material2, material3, material4, material5, material6, material7, material8 };
        current_material = materials[material_number];
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
            new_step.GetComponent<SpriteRenderer>().material = current_material;
            new_step.GetComponent<SpriteRenderer>().material.mainTextureScale = new Vector2(new_step.transform.localScale.x, new_step.transform.localScale.y);


            step_count++;

            if (step_count % 25 == 0)
            {
                new_step.transform.position = transform.position;
                new_step.transform.localScale = new Vector3(5.80f, new_step.transform.localScale.y, new_step.transform.localScale.z);
                if(step_count % 50 == 0 && material_number<7)
                {
                    material_number++;
                    current_material = materials[material_number];
                    new_step.GetComponent<SpriteRenderer>().material = current_material;
                    new_step.GetComponent<SpriteRenderer>().material.mainTextureScale = new Vector2(new_step.transform.localScale.x, new_step.transform.localScale.y);


                }



            }


            CheckPointScript.make_steps = false;
        }



    }


}
