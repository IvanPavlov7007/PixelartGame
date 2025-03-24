using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBikeVisualController : MonoBehaviour
{

    [SerializeField]
    BikeControl bikeControl;
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

    void Update()
    {
        var dir = bikeControl.direction.x;
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
