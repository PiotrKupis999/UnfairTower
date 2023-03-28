using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{

    public GameObject player;
    public static bool is_moving = false;
    public GameObject background;
    public GameObject steps;

    [Header("UI")]
    public GameObject left_but;
    public GameObject right_but;
    public GameObject info_bar;
    public GameObject score;
    public Text best_score_text;

    private Color transparency = new(255f, 255f, 255f, 0.1f);

    public static int level;
    public static int best_score;
    private float next_level;


    private void Awake()
    {
        PlayerPrefs.GetInt("best_score", best_score);

    }


    // Start is called before the first frame update
    void Start()
    {
        next_level = 0;
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
                score.GetComponent<Text>().text = "2";

            }
            
        }

        if (player.transform.position.y > next_level)
        {
            level++;
            next_level += 1.034095f;
            score.GetComponent<Text>().text = level.ToString();

        }
        
        if (best_score + 1 < next_level)
        {
            best_score_text.color = Color.green;
            best_score = level;
        }
        

        best_score_text.text = "best score:\n" + best_score.ToString();


        background.transform.position = new Vector3(-0.15f, Camera.main.transform.position.y, 1f);

        
    }


}
