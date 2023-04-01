using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCotroller : MonoBehaviour
{
    SoundManagerScript soundManager;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public static int music_settings;
    public static int sound_settings;

    private void Start()
    {

        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();


    }



    // Start is called before the first frame update
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SwitchButtonMusic(TextMeshProUGUI text)
    {

        if (music_settings == 1)
        {
            text.GetComponent<TextMeshProUGUI>().enabled = false;
            soundManager.PlayMusic();
            music_settings = 0;
        }
        else
        {
            text.GetComponent<TextMeshProUGUI>().enabled = true;
            soundManager.StopMusic();
            music_settings = 1;

        }
        

    }

    public void SwitchButtonSounds(TextMeshProUGUI text)
    {

        if (sound_settings == 1)
        {
            text.GetComponent<TextMeshProUGUI>().enabled = false;
            SoundManagerScript.soundsEnable = true;
            sound_settings = 0;
        }
        else
        {
            text.GetComponent<TextMeshProUGUI>().enabled = true;
            SoundManagerScript.soundsEnable = true;
            sound_settings = 1;
        }


    }

    public void ClickSound()
    {
        soundManager.PlaySound(SoundManagerScript.Sounds.clickSound);
    }

    public void PauseGame()
    {
        GameControllerScript.is_moving = false;
    }



}
