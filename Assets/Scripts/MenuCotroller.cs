using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class MenuCotroller : MonoBehaviour
{
    SoundManagerScript soundManager;
    AdsScript adsManager;
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
            SoundManagerScript.soundsEnable = false;
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

    public void CountineGame()
    {
        
        while (Advertisement.isShowing)
        {
            Debug.Log("czekaj");
        }

        Destroy(GameObject.FindGameObjectWithTag("RestartBars"));
        GameControllerScript.is_moving = true;
        BrokerScript.fall = false;
        GameControllerScript.first_try = false;
        GameControllerScript.one_time = true;


    }
    /*
    public void PlayAd()
    {
        OnUnityAdsAdLoaded("Rewarded_Android");
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
        Advertisement.Show(adUnitId);

    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        throw new System.NotImplementedException();
    }
    */
}
