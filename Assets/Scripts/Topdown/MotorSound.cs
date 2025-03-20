﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSound : MonoBehaviour
{
    AudioSource aud;
    public float minPitch, maxPitch;
    public float minStereo, maxStereo;

    [SerializeField]
    BikeControl bike;

    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        aud.pitch = Mathf.Lerp(minPitch, maxPitch, bike.speedUp);
        aud.panStereo = Mathf.Lerp(minStereo, maxStereo, bike.panX);

    }
}
