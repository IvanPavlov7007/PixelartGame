using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleHitReceiver : HitReciever
{
    public event System.Action<VehicleHitReceiver> hitRecieved;
    public override void ReceiveHit(Collider collision)
    {
        hitRecieved?.Invoke(this);
    }
}
