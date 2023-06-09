using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public enum Sounds
    {
        stepSound,
        clickSound,
        fallSound,
        music
    }

    AudioSource audiosrc;

    [Header("AudioClips")]
    public AudioClip stepSound_clip;
    public AudioClip clickSound_clip;
    public AudioClip fallSound_clip;
    public AudioClip music_clip;

    public static bool soundsEnable = true;

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("SoundManager").Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMusic()
    {
        audiosrc.Play();
    }

    public void StopMusic()
    {
        audiosrc.Stop();
    }

    public void PlaySound(Sounds sound)
    {
        if (!soundsEnable) return;

        switch(sound)
        {
            case Sounds.stepSound:
                audiosrc.PlayOneShot(stepSound_clip);
                break;
            case Sounds.clickSound:
                audiosrc.PlayOneShot(clickSound_clip);
                break;
            case Sounds.fallSound:
                audiosrc.PlayOneShot(fallSound_clip);
                break;
        }
    }
}
