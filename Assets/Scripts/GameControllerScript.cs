using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{

    public GameObject player;
    public static bool is_moving = false;
    public GameObject background;
    public GameObject steps;

    [Header("Buttons")]
    public GameObject left_but;
    public GameObject right_but;
    public GameObject info_bar;

    private Color transparency = new(255f, 255f, 255f, 50f);
     




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (player.transform.position.y > 1f)
        {
            is_moving = true;
            //background.GetComponent<Animator>().enabled = true;
            if (!info_bar.IsDestroyed())
            {
                Destroy(info_bar);
            }

            left_but.GetComponent<Image>().color = transparency;
            right_but.GetComponent<Image>().color = transparency;
        }


        background.transform.position = new Vector3(-0.15f, Camera.main.transform.position.y, 1f);

        
    }


}
