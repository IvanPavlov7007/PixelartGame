using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeVisualController : MonoBehaviour
{
    CharacterMovement characterController;
    SpriteRenderer sr;

    public Sprite sideSprite;

    [Range(0f,1f)]
    public float tolerance = 0.2f;

    Sprite origSprite;

    void Start()
    {
        characterController = GetComponent<CharacterMovement>();
        sr = GetComponentInChildren<SpriteRenderer>();
        origSprite = sr.sprite;
    }

    void Update()
    {
        var dir = characterController.direction.x;
        if (dir > tolerance || dir < -tolerance)
        {
            sr.sprite = sideSprite;
            sr.flipX = dir > tolerance;
        }
        else
            sr.sprite = origSprite;
    }
}
