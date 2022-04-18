using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public static RoadManager instance { get; private set; }

    public float rotationAccelerator = 1f;

    ScrollerStage[] stages;
    public float speed { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed * rotationAccelerator;
    }
}
