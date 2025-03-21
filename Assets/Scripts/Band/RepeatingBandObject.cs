using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBandObject : BandObject
{
    //TODO Make actually an array or something, so that there actually were many of them!

    [Header("Repeating Settings")]
    public float periodDistance = 2f;
    public float offsetDistance = 0f;
    public float startingDistance = -100f;

    public void updateRepeatingPosition(float currentPosition)
    {
        var closestPosition = determineClosestPeriodicPosition(currentPosition);
        //TODO add better constraints?
        if (closestPosition <= startingDistance)
            closestPosition = float.PositiveInfinity;
        bandPosition = closestPosition;
    }

    protected float determineClosestPeriodicPosition(float currentPosition)
    {
        float pos_inPeriod = (currentPosition - offsetDistance) % periodDistance;
        if (pos_inPeriod < 0f)
            pos_inPeriod = periodDistance + pos_inPeriod;

        float globalPos_left = currentPosition - pos_inPeriod;
        float globalPos_right = currentPosition + (periodDistance - pos_inPeriod);

        float distToLeft = currentPosition - globalPos_left;
        float distToRight = globalPos_right - currentPosition;

        if (distToLeft <= distToRight)
        {
            return globalPos_left;
        }
        else
            return globalPos_right;
    }


}
