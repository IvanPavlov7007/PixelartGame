using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideRepresentation : Representation
{
    public float parallaxRange = 1f;
    public float xBoundary = 20f;

    public override void Draw(float bandPosition)
    {
        //translating into camera coordinates
        var delta = parallaxPosition(bandPosition);
        if (Mathf.Abs(delta) <= xBoundary)
        {
            setWorldPos(delta);
        }
        else
        {
            //hide
            setWorldPos(2 * xBoundary);
        }
    }

    /// <summary>
    /// distant moving objects like clouds or mountains move on a further plane, which is compressed relative to this one
    /// or opposite for the foreground objects
    /// </summary>
    /// <returns></returns>
    protected virtual float parallaxPosition(float currentPosition)
    {
        //if paralaxRange = 1 equation becomes  return xBandPosition - currentPosition
        return (bandObject.bandPosition - currentPosition) / parallaxRange;
    }

    protected virtual void setWorldPos(float xPos)
    {
        var pos = transform.position;
        pos.x = xPos;
        transform.position = pos;
    }
}
