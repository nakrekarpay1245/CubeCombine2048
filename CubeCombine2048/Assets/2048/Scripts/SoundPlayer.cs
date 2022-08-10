using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    public static SoundPlayer soundPlayer;

    private void Awake()
    {
        if (!soundPlayer)
        {
            soundPlayer = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPopSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
