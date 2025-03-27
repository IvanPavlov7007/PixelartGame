using System.Collections;
using UnityEngine;

public class HitRepresentation : RepresentationComponent
{
    protected virtual void onHitReceived(VehicleHitReceiver hitReceiver) { }
    protected override void initialize(BandObject bandObject)
    {
        var hitReceiver = bandObject.GetComponent<VehicleHitReceiver>();
        if (hitReceiver != null)
            hitReceiver.hitRecieved += onHitReceived;
    }

}