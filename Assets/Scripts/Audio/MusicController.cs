using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    AudioClip relaxedClip, tenseClip;
    [SerializeField]
    TransitioningMusic transitioningMusic;

    public float minSpeedToRelaxed = 3f;
    public float maxSpeedToTense = 5f;
    public enum Tempo { Relaxed,Tense}
    public Tempo currentTempo { get; private set; }

    private void Start()
    {
        currentTempo = Tempo.Relaxed;
        transitioningMusic.Initialize(relaxedClip);
    }

    private void Update()
    {
        switch (currentTempo)
        {
            case Tempo.Relaxed:
                {
                if (GameManager.Instance.speedController.currentSpeed > maxSpeedToTense)
                {
                        transitioningMusic.TransitionTrack(tenseClip);
                        currentTempo = Tempo.Tense;
                }
                break;
                }
            case Tempo.Tense:
                if (GameManager.Instance.speedController.currentSpeed < minSpeedToRelaxed)
                {
                    transitioningMusic.TransitionTrack(relaxedClip);
                    currentTempo = Tempo.Relaxed;
                }
                break;
            default:
                Debug.LogError("State doesn't existing");
                break;
        }
    }
}
