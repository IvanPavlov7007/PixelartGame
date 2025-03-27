using System.Collections;
using UnityEngine;
using Pixelplacement;
public class SpriteBlinkOnHit : HitRepresentation
{
    [SerializeField]
    SpriteRenderer s;
    [SerializeField]
    Color initColor;
    [SerializeField]
    Color endColor;

    float halfTime = 0.1f;
    protected override void onHitReceived(VehicleHitReceiver hitReceiver)
    {
        if(s == null)
            s = GetComponentInChildren<SpriteRenderer>();
        Tween.Color(s, endColor, halfTime, 0f);
        Tween.Color(s, initColor, halfTime, halfTime);
    }

}