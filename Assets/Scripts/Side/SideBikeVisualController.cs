using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBikeVisualController : RepresentationComponent
{

    [SerializeField]
    BikeControl bikeControl;
    [SerializeField]
    Vehicle vehicle;
    [SerializeField]
    public Sprite leaningLeft, leaninghRight;
    SpriteRenderer sr;

    [Range(0f, 1f)]
    public float tolerance = 0.2f;

    Sprite origSprite;
    private void Start()
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
        if (dir > tolerance)
        {
            sr.sprite = leaninghRight;
        }
        else if (dir < -tolerance)
        {
            sr.sprite = leaningLeft;
        }
        else
        {
        { 
            sr.sprite = origSprite;
        }
        }
    }

}
