using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;
    //private float AudioListener;

    void Start()
    {
        audioSource = GetComponent <AudioSource>();
    }

    //public methods
    public void PlayOneShot(AudioClip clip)
    {
        if(clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void ToggleSounds()
    {
       //when the soundcontroller script is dragged onto the sound button the below code should mute and unmute the sound.
        audioSource.mute = !audioSource.mute;
        
    }

    public static SoundController FindSoundController()
    {
        SoundController sc = FindObjectOfType<SoundController>();
        if(!sc)
        {
            Debug.LogWarning("Missing Sound Controller");
        }
        return sc;
    }


}
//https://www.youtube.com/watch?v=DpgFgqrKi0A watched this youtube video to toggle sounds