using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private List<AudioSource> audioSources = new List<AudioSource>();
    public AudioSource leadingSource { get; private set; }
    private List<AudioSource> activeSources = new List<AudioSource>();

}
