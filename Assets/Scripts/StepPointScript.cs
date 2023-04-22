using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPointScript : MonoBehaviour
{
    //invisible steps for counting points

    public GameObject player;
    public SoundManagerScript soundManager;


    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();
    }

    void Update()
    {
        if (player.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
        else
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameControllerScript.level++;

            if (GameControllerScript.level % 50 == 0 && GameControllerScript.level < 355)
            {
                CameraHolder.camera_speed += 0.33f;
            }
            soundManager.PlaySound(SoundManagerScript.Sounds.stepSound);
            Destroy(this.gameObject);
        }
        
    }
}
