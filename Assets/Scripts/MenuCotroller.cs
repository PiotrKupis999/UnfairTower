using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCotroller : MonoBehaviour
{
    SoundManagerScript soundManager;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();

    }
    // Start is called before the first frame update
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SwitchButton(TextMeshProUGUI text)
    {
        if (text.GetComponent<TextMeshProUGUI>().enabled)
        {
            text.GetComponent<TextMeshProUGUI>().enabled = false;
        }
        else
        {
            text.GetComponent<TextMeshProUGUI>().enabled = true;

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
