using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAdjuster : BandLogicComponent
{
    public float adjustDistance = 1.5f;
    public float relativeDifference = 0.5f;
    Vehicle vehicle;

    protected override void Start()
    {
        base.Start();
        vehicle = GetComponent<Vehicle>();
    }

    public override void onLogicUpdate(BandObject bandObject, float scenePosition)
    {
        float distance = bandObject.bandPosition - scenePosition;
        if (Mathf.Abs(distance) < adjustDistance)
        {
            vehicle.velocityAlongAxes = new Vector3(0f, Mathf.Max(0f, GameManager.Instance.speedController.currentSpeed + relativeDifference), 0f);
            enabled = false;
        }
    }
}
