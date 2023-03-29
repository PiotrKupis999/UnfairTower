using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public enum Sounds
    {
        stepSound
    }

    AudioSource audiosrc;

    public AudioClip clip;
    public AudioClip clip1;
    public AudioClip clip2;

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

    public void PlaySound(Sounds sound)
    {
        switch(sound)
        {
            case Sounds.stepSound:
                audiosrc.PlayOneShot(clip);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
