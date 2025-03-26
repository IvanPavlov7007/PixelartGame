using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeVehicle : BandLogicComponent
{
    public float unfreezeDistance = 1.5f;
    Vehicle vehicle;


    protected override void Start()
    {
        base.Start();
        vehicle = GetComponent<Vehicle>();
    }

    public override void onLogicUpdate(BandObject bandObject, float scenePosition)
    {
        float distance = bandObject.bandPosition - scenePosition;
        if (Mathf.Abs(distance) < unfreezeDistance)
            vehicle.enabled = true;
        else
            vehicle.enabled = false;
    }
}
