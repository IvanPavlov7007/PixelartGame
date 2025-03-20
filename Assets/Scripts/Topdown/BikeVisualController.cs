using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeVisualController : MonoBehaviour
{
    [SerializeField]
    BikeControl bikeControl;
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

    void Update()
    {
        var dir = bikeControl.direction.x;
        if (dir > tolerance || dir < -tolerance)
        {
            sr.sprite = sideSprite;
            sr.flipX = dir > tolerance;
        }
        else
            sr.sprite = origSprite;
    }
}
