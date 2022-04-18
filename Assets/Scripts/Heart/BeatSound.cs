using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSound : MonoBehaviour
{
    AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void PlayBeat()
    {
        aud.Stop();
        aud.PlayOneShot(aud.clip);
    }
}
