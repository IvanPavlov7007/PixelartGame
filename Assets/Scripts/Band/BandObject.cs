using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BandObject : MonoBehaviour
{
    public float bandPosition;
    public float bandWidthPosition; // TODO make a vector of a structure
    public float bandHightPosition;
    public void UpdateLogic(float scenePosition)
    {
        transform.position = new Vector3(bandWidthPosition, bandPosition, bandHightPosition);
        onLogicUpdate?.Invoke(this, scenePosition);
    }


    public event Action<BandObject, float> onLogicUpdate;
    public event Action<BandObject> onDestroyed;

    protected virtual void OnDestroy()
    {
        onDestroyed?.Invoke(this);
    }
}