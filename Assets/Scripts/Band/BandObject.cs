using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandObject : MonoBehaviour
{
    public virtual float bandPosition { get; set; }
    public virtual float bandWidthPosition { get; set; } // TODO make a vector of a structure

    public virtual void Start()
    {
        WorldBand.Instance.registerBandObject(this);
    }

    protected virtual void OnDisable()
    {
        WorldBand.Instance.removeBandObject(this);
    }
}