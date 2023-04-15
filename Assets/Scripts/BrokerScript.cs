using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrokerScript : MonoBehaviour
{
    public static bool fall;
    SoundManagerScript soundManager;

    void Start()
    {
        fall = false;
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y - 6.2f, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //stop game and save best score
        if (collision.CompareTag("Player"))
        {
            soundManager.PlaySound(SoundManagerScript.Sounds.fallSound);
            GameControllerScript.is_moving = false;

            PlayerPrefs.SetInt("best_score", GameControllerScript.best_score);
            PlayerPrefs.Save();            

            RestartingScript.playerEndPosition = collision.gameObject.transform.position;

            fall = true;
        }
        else
        {
            Destroy(collision.gameObject);

        }


    }
}
