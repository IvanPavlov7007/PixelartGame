using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpeedManager : MonoBehaviour
{
    public static RoadSpeedManager instance { get; private set; }

    public float speedAccelerator = 1f, minSpeed = 0.3f;

    RoadManager road;
    BikeTopdownControl bike;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        road = RoadManager.instance;
        bike = PlayerMovement.Instance.GetComponent<BikeTopdownControl>();
    }

    void Update()
    {
        float t = bike.speedUp;
        road.SetSpeed(t * speedAccelerator + minSpeed);
    }
}
