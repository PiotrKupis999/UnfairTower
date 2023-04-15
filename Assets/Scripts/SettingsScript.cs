using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;


    private void Start()
    {
        if (MenuCotroller.music_settings == 1)
        {
            text1.GetComponent<TextMeshProUGUI>().enabled = true;
        }

        if (MenuCotroller.sound_settings == 1)
        {
            text2.GetComponent<TextMeshProUGUI>().enabled = true;
        }

    }


}
