using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    AudioSource audioS;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        playMusic();
    }

    public void playMusic()
    {
        audioS.Play();
    }
}
