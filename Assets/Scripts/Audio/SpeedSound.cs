using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSound : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    public float minPitch = 0.75f;
    public float maxPitch = 3f;
    public float minSpeed = 0f;
    public float maxSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        audioSource.pitch = Mathf.Lerp(minPitch, maxPitch, Mathf.InverseLerp(minSpeed, maxSpeed, GameManager.Instance.speedController.currentSpeed));
    }
}
