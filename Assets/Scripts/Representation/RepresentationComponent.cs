using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepresentationComponent : MonoBehaviour
{
    protected virtual void initialize(BandObject bandObject)
    {

    }

    public void RepresentationInitialize(BandObject bandObject)
    {
        initialize(bandObject);
    }
}
