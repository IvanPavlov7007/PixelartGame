using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float maxX;
    public float minX;
    public Vector3 velocityAlongAxes;
    public Vector3 direction = Vector3.up;


    private void Start()
    {
        GetComponent<BandObject>().onLogicUpdate += onLogicUpdate;
    }

    void onLogicUpdate(BandObject bandObject)
    {
        float deltaX = direction.x * Time.deltaTime * velocityAlongAxes.x;
        float deltaY = direction.y * Time.deltaTime * velocityAlongAxes.y;

        Vector3 curPos = new Vector3(bandObject.bandWidthPosition, bandObject.bandPosition, 0f);

        bandObject.bandWidthPosition = Mathf.Clamp(curPos.x + deltaX, minX, maxX);
        bandObject.bandPosition = curPos.y + deltaY;
    }
}
