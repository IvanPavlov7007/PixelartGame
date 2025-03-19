using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandObject : MonoBehaviour
{
    public virtual float bandPosition { get; set; }
    public virtual float boundary { get; set; }

    public virtual void Start()
    {
        WorldBand.Instance.registerBandObject(this);
    }

    protected virtual void OnDestroy()
    {
        WorldBand.Instance.removeBandObject(this);
    }

    public virtual void UpdateWorldPosition(float currentPosition)
    {
    }
}

[System.Serializable]
public struct ScreenContext
{
    public Transform center;
    public Rect worldRect;
}