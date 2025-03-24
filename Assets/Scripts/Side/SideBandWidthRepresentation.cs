using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBandWidthRepresentation : SideRepresentation
{
    public float minY = -0.2f;
    public float maxY = 0f;
    public float minBandWidth = -1f;
    public float maxBandWidth = 1f;

    float initY;
    private void Start()
    {
        initY = transform.localPosition.y;

    }
    public override void Draw(float bandPosition)
    {
        //translating into camera coordinates
        var delta = parallaxPosition(bandPosition);
        var sideY = calculateCompressedBandPosition();

        if (Mathf.Abs(delta) <= xBoundary)
        {
            setWorldPos(delta, sideY);
        }
        else
        {
            //hide
            setWorldPos(2 * xBoundary, sideY);
        }
    }

    protected virtual float calculateCompressedBandPosition()
    {
        float t = Mathf.InverseLerp(minBandWidth,maxBandWidth, bandObject.bandWidthPosition);
        return initY + Mathf.Lerp(minY, maxY, t);
    }

    protected virtual void setWorldPos(float xPos, float yPos)
    {


        var pos = transform.localPosition;
        pos.x = xPos;
        pos.y = yPos;
        transform.localPosition = pos;
    }
}
