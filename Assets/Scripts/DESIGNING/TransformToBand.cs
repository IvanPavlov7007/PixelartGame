using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToBand : TransformToBandParent
{
    BandObject _bo;
    BandObject bandObject { get { if (_bo == null) _bo = GetComponent<BandObject>(); return _bo; } }

    public Axis bandDirection = Axis.X;
    public Axis bandWidthDirection = Axis.Z;
    public Axis bandHightDirection = Axis.Y;
    public void PositionToBandValues(Vector3 pos)
    {
        float bandPos = bandObject.bandPosition;
        float bandWidthPos = bandObject.bandWidthPosition;
        float bandHightPosition = bandObject.bandHightPosition;
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

        switch (bandHightDirection)
        {
            case Axis.X:
                bandHightPosition = pos.x;
                break;
            case Axis.Y:
                bandHightPosition = pos.y;
                break;
            case Axis.Z:
                bandHightPosition = pos.z;
                break;
            case Axis.None:
                break;
        }
        bandObject.bandPosition = bandPos;
        bandObject.bandWidthPosition = bandWidthPos;
        bandObject.bandHightPosition = bandHightPosition;
    }

    [System.Serializable]
    public enum Axis { X, Y, Z, None}

    private void Awake()
    {
        PositionToBandValues(GetPositionInHighestTransformToBandParentSpace());
    }

    public Vector3 GetPositionInHighestTransformToBandParentSpace()
    {
        Transform highestTransformToBand = FindHighestTransformToBandParent();

        if (highestTransformToBand == null)
            throw new UnityException(name + " should be a highest TransformToBandParent itself");

        Transform parentOfHighestTransformToBand = highestTransformToBand.parent;
        if (parentOfHighestTransformToBand == null)
            return transform.position; // Highest parent is root, use local position

        return parentOfHighestTransformToBand.InverseTransformPoint(transform.position);
    }

    private Transform FindHighestTransformToBandParent()
    {
        Transform highestTransformToBandParent = null;
        Transform current = transform;

        while (current != null)
        {
            if (current.GetComponent<TransformToBandParent>() != null)
                highestTransformToBandParent = current;

            current = current.parent;
        }

        return highestTransformToBandParent;
    }
}
