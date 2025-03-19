using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingSideViewBandObject : SideViewBandObject
{
    [Header("Repeating Settings")]
    public float periodDistance = 2f;
    public float offsetDistance = 0f;
    public float startingDistance = 0f;

    public override void UpdateWorldPosition(float currentPosition)
    {
        //if the stage with repeating parts not yet arrived
        if (currentPosition <= startingDistance - boundary)
        {
            setWorldPos(2f * boundary);
            return;
        }


        determineClosestPeriodicPosition(currentPosition);
        base.UpdateWorldPosition(currentPosition);
    }

    protected void determineClosestPeriodicPosition(float currentPosition)
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
            bandPosition = globalPos_left;
        }
        else
            bandPosition = globalPos_right;

    }
}
