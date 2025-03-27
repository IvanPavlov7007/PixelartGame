using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeVisualController : RepresentationComponent
{
    [SerializeField]
    BikeControl bikeControl;
    [SerializeField]
    Vehicle vehicle;
    SpriteRenderer sr;

    public Sprite sideSprite;

    [Range(0f,1f)]
    public float tolerance = 0.2f;

    Sprite origSprite;

    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        origSprite = sr.sprite;
    }

    protected override void initialize(BandObject bandObject)
    {
        bikeControl = bandObject.GetComponent<BikeControl>();
        vehicle = bandObject.GetComponent<Vehicle>();
    }

    void Update()
    {
        var dir = vehicle.enabled? vehicle.direction.x : bikeControl.direction.x;
        if (dir > tolerance || dir < -tolerance)
        {
            sr.sprite = sideSprite;
            sr.flipX = dir > tolerance;
        }
        else
            sr.sprite = origSprite;
    }
}
