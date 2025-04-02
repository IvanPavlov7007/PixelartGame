using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitioningMusic : MonoBehaviour
{
    [SerializeField] AudioSource aAudioSource;
    [SerializeField] AudioSource bAudioSource;
    public float transitionTime;

    Coroutine transitionRoutine;

    public void Initialize(AudioClip initialClip)
    {
        if (transitionRoutine != null)
        {
            StopCoroutine(transitionRoutine);
            transitionRoutine = null;
        }
        aAudioSource.clip = null;
        aAudioSource.volume = 0f;
        bAudioSource.clip = initialClip;
        bAudioSource.volume = 1f;

        aAudioSource.loop = true;
        bAudioSource.loop = true;

        bAudioSource.Play();
    }

    public void TransitionTrack(AudioClip clip)
    {
        if (transitionRoutine != null)
        {
            StopCoroutine(transitionRoutine);
            transitionRoutine = null;
        }
        swapTracks();
        bAudioSource.clip = clip;
        transitionTracks();
    }

    private void transitionTracks()
    {
        if (transitionRoutine == null)
        {
            bAudioSource.Play();
            transitionRoutine = StartCoroutine(volumeTransition(transitionTime));
        }
    }

    private void swapTracks()
    {
        var c = bAudioSource;
        bAudioSource = aAudioSource;
        aAudioSource = c;
    }

    IEnumerator volumeTransition(float transitionTime)
    {
        float n = 0f;
        float initAVolume = aAudioSource.volume;
        float initBVolume = bAudioSource.volume;
        while (n < transitionTime)
        {
            n += Time.deltaTime;
            aAudioSource.volume = Mathf.Lerp(initAVolume, 0f, n / transitionTime);
            bAudioSource.volume = Mathf.Lerp(initBVolume, 1f, n / transitionTime);
            yield return new WaitForEndOfFrame();
        }
        aAudioSource.volume = 0f;
        bAudioSource.volume = 1f;
        transitionRoutine = null;
        yield return null;
    }
}
