using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToBand : MonoBehaviour
{
    BandObject _bo;
    BandObject bandObject { get { if (_bo == null) _bo = GetComponent<BandObject>(); return _bo; } }

    public Axis bandDirection = Axis.X;
    public Axis bandWidthDirection = Axis.Z;
    
    public void LocalPositionToBandValues()
    {
        Vector3 pos = transform.localPosition;
        float bandPos = bandObject.bandPosition;
        float bandWidthPos = bandObject.bandWidthPosition;
        switch (bandDirection)
        {
            case Axis.X:
                bandPos = pos.x;
                break;
            case Axis.Y:
                bandPos = pos.y;
                break;
            case Axis.Z:
                bandPos = pos.z;
                break;
            case Axis.None:
                break;
        }

        switch (bandWidthDirection)
        {
            case Axis.X:
                bandWidthPos = pos.x;
                break;
            case Axis.Y:
                bandWidthPos = pos.y;
                break;
            case Axis.Z:
                bandWidthPos = pos.z;
                break;
            case Axis.None:
                break;
        }
        bandObject.bandPosition = bandPos;
        bandObject.bandWidthPosition = bandWidthPos;
    }

    [System.Serializable]
    public enum Axis { X, Y, Z, None}
}
