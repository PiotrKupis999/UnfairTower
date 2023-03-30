using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public enum Sounds
    {
        stepSound,
        clickSound,
        music
    }

    AudioSource audiosrc;

    public AudioClip stepSound_clip;
    public AudioClip clickSound_clip;
    public AudioClip music_clip;

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
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (audiosrc.isPlaying) return;
        audiosrc.Play();
    }

    public void PlaySound(Sounds sound)
    {
        switch(sound)
        {
            case Sounds.stepSound:
                audiosrc.PlayOneShot(stepSound_clip);
                break;
            case Sounds.clickSound:
                audiosrc.PlayOneShot(clickSound_clip);
                break;
                /*
            case Sounds.music:
                audiosrc.PlayOneShot(music_clip);
                break;
                */
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
