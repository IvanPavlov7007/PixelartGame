using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeTopdownControl : MonoBehaviour, CharacterMovement
{
    public float maxX, minX, maxY, minY;
    public float ySpeed, xSpeed;

    public float speed { get; set; }
    public Vector3 direction { get; set; }

    public float speedUp { get; private set; }
    public float panX { get; private set; }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = direction.x * Time.deltaTime * xSpeed;
        float deltaY = direction.y * Time.deltaTime * ySpeed;

        var curPos = transform.position;

        float newX = Mathf.Clamp(curPos.x + deltaX, minX, maxX);
        float newY = Mathf.Clamp(curPos.y + deltaY, minY, maxY);

        transform.position = new Vector3(newX, newY, 0);
        var pos = transform.position;
        speedUp = Mathf.InverseLerp(minY, maxY, pos.y);
        panX = Mathf.InverseLerp(minX, maxX, pos.x);
    }



}
