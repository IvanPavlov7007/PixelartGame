using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideViewBandObject : BandObject
{
    [Tooltip("Values bigger than 1 slow down the object(put onto background) \nvalues less than 1 speed up (put onto foreground) \n1 means the object renders at the camera's plane ")]
    public float paralaxRange = 1f;
    public float xBandPosition;
    public float xBoundary = 20f;
    public override float bandPosition { get => xBandPosition; set => xBandPosition = value; }
    public override float boundary { get => xBoundary; set => xBoundary = value; }
    public override void UpdateWorldPosition(float currentPosition)
    {
        //translating into camera coordinates
        var delta = paralaxPosition(currentPosition);
        if (Mathf.Abs(delta) <= xBoundary)
        {
            setWorldPos(delta);
        }
        else
        {
            //hide
            setWorldPos(2 * boundary);
        }
    }

    /// <summary>
    /// distant moving objects like clouds or mountains move on a further plane, which is compressed relative to this one
    /// or opposite for the foreground objects
    /// </summary>
    /// <returns></returns>
    protected virtual float paralaxPosition(float currentPosition)
    {
        //if paralaxRange = 1 equation becomes  return xBandPosition - currentPosition
        return (xBandPosition - currentPosition) / paralaxRange;
    }

    protected virtual void setWorldPos(float xPos)
    {
        var pos = transform.position;
        pos.x = xPos;
        transform.position = pos;
    }
}
