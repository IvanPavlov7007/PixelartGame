using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class SideSorting : Singleton<SideSorting>
{
    public int leftMostOrder;
    public int rightMostOrder;

    public float leftMostBandWidthPos;
    public float rightMostBandWidthPos;

    public float minY = -0.2f;
    public float maxY = 0f;

    public int sortingOrderForPostion(float bandWidthPosition)
    {
        float t = Mathf.InverseLerp(leftMostBandWidthPos, rightMostBandWidthPos, bandWidthPosition);
        int pos = Mathf.RoundToInt(Mathf.Lerp(leftMostOrder, rightMostOrder, t));
        return pos;
    }
    public float calculateCompressedBandPosition(float bandWidthPosition)
    {
        float t = Mathf.InverseLerp(leftMostBandWidthPos, rightMostBandWidthPos, bandWidthPosition);
        return Mathf.Lerp(minY, maxY, t);
    }

}
