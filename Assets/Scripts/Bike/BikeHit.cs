using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeHit : HitReciever
{
    [SerializeField]
    BikeControl bikeControl;

    public override void ReceiveHit(Collider collision)
    {
        SpeedController.SpeedPunishment.Punish();
    }
}
