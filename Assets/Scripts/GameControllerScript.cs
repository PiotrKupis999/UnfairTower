using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{

    public GameObject player;
    public static bool is_moving = false;
    public GameObject background;
    public GameObject steps;

    SoundManagerScript soundManager;
    AudioSource audioSource;
    AdsScript adsManager;


    [Header("UI")]
    public GameObject left_but;
    public GameObject right_but;
    public GameObject info_bar;
    public GameObject restart_bar;
    public GameObject score;
    public Text best_score_text;



    private Color transparency = new(255f, 255f, 255f, 0.1f);
    public static bool one_time;

    public static int level;
    public static int best_score;


    private void Awake()
    {
        if (PlayerPrefs.HasKey("best_score"))
        {
            PlayerPrefs.SetInt("best_score", best_score);
        }

    }
    

    
    // Start is called before the first frame update
    void Start()
    {
        one_time = true;

        level = 0;
        CameraHolder.camera_speed = 1f;
        audioSource = GetComponent<AudioSource>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (player.transform.position.y > -0.7f)
        {
            
            //background.GetComponent<Animator>().enabled = true;
            if (!info_bar.IsDestroyed())
            {
                score.GetComponent<Text>().enabled = true;
                Destroy(info_bar);
                is_moving = true;
                left_but.GetComponent<Image>().color = transparency;
                right_but.GetComponent<Image>().color = transparency;


            }


            score.GetComponent<Text>().text = level.ToString();
            //soundManager.PlaySound(SoundManagerScript.Sounds.stepSound);


        }


        if (best_score < level)
        {
            best_score_text.color = Color.green;
            best_score = level;
        }
        

        best_score_text.text = "best score:\n" + best_score.ToString();


        background.transform.position = new Vector3(0, Camera.main.transform.position.y, 1f);

        if (BrokerScript.fall && one_time)
        {
            GameObject new_restart_bar = Instantiate(restart_bar);
            new_restart_bar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            one_time = false;
            

        }






    }


}
