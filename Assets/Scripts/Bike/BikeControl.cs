using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BandObject))]
public class BikeControl : MonoBehaviour
{
    public float maxX, minX, maxY, minY;
    public float ySpeed, xSpeed;

    public Vector3 worldPosition;

    public float speed { get; set; }
    public Vector3 direction { get; set; }
    public float speedUp { get; private set; }
    public float panX { get; private set; }

    public BandObject bandObject;

    // Update is called once per frame
    public void UpdateInputs()
    {
        float deltaX = direction.x * Time.deltaTime * xSpeed;
        float deltaY = direction.y * Time.deltaTime * ySpeed;

        var curPos = worldPosition;

        float newX = Mathf.Clamp(curPos.x + deltaX, minX, maxX);
        float newY = Mathf.Clamp(curPos.y + deltaY, minY, maxY);

        worldPosition = new Vector3(newX, newY, 0);
        speedUp = Mathf.InverseLerp(minY, maxY, worldPosition.y);
        panX = Mathf.InverseLerp(minX, maxX, worldPosition.x);
    }

    public void UpdateBandObjectPosition(float currentScenePosition)
    {
        bandObject.bandPosition = currentScenePosition + worldPosition.y;
        bandObject.bandWidthPosition = worldPosition.x;
    }
}
