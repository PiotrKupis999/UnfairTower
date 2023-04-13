using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCotroller : MonoBehaviour
{
    enum ContinueButtonModes
    {
        PlayAdMode,
        ContinueGameMode
    }
    

    SoundManagerScript soundManager;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public static int music_settings;
    public static int sound_settings;
    static bool first_try;
    private float continue_time = 9f;
    static ContinueButtonModes mode;

    private void Start()
    {

        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>();
        first_try = true;
        mode = ContinueButtonModes.PlayAdMode;
    }

    private void Update()
    {
        Debug.Log(mode);
        switch (mode)
        {
            case ContinueButtonModes.PlayAdMode:
                if (GameObject.FindGameObjectWithTag("ContinueButton") != null && first_try)
                {

                    continue_time -= Time.deltaTime;
                    GameObject.FindGameObjectWithTag("ContinueButton").GetComponentInChildren<Text>().text = "▷ watch ad " + Mathf.Clamp(Mathf.CeilToInt(continue_time), 0, 9);

                    if (continue_time < 0)
                    {
                        GameObject.FindGameObjectWithTag("ContinueButton").GetComponent<Button>().interactable = false;

                    }

                }
                else if (GameObject.FindGameObjectWithTag("ContinueButton") != null && !first_try)
                {
                    GameObject.FindGameObjectWithTag("ContinueButton").GetComponent<Button>().interactable = false;
                }
                break;
            case ContinueButtonModes.ContinueGameMode:

                GameObject.FindGameObjectWithTag("ContinueButton").GetComponent<Button>().interactable = true;

                GameObject.FindGameObjectWithTag("ContinueButton").GetComponentInChildren<Text>().text = "▷ Continue";
                break;
        }


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

    public void ResetScore()
    {
        GameControllerScript.best_score = 0;
    }

    public void CountineGame()
    {


        switch (mode)
        {
            case ContinueButtonModes.PlayAdMode:
                mode = ContinueButtonModes.ContinueGameMode;
                

                GameObject.FindGameObjectWithTag("AdsManager").GetComponent<AdsScript>().LoadRewardedAd();
                GameObject.FindGameObjectWithTag("AdsManager").GetComponent<AdsScript>().ShowRewardedAd();
                first_try = false;
                break;
            case ContinueButtonModes.ContinueGameMode:
                Destroy(GameObject.FindGameObjectWithTag("RestartBars"));
                GameControllerScript.is_moving = true;
                BrokerScript.fall = false;
                GameControllerScript.one_time = true;
                mode = ContinueButtonModes.PlayAdMode;

                break;
        }
        


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
