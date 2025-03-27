using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSound : RepresentationComponent
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

    protected override void initialize(BandObject bandObject)
    {
        bike = bandObject.GetComponent<BikeControl>();
    }

    // Update is called once per frame
    void Update()
    {
        aud.pitch = Mathf.Lerp(minPitch, maxPitch, bike.speedUp);
        aud.panStereo = Mathf.Lerp(minStereo, maxStereo, bike.panX);

    }
}
