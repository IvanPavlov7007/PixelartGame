using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BandObject : MonoBehaviour
{
    public float bandPosition;
    public float bandWidthPosition; // TODO make a vector of a structure
    public void UpdateLogic()
    {
        onLogicUpdate?.Invoke(this);
    }


    public event Action<BandObject> onLogicUpdate;
    public event Action<BandObject> onDestroyed;

    protected virtual void OnDestroy()
    {
        onDestroyed?.Invoke(this);
    }
}