using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class WorldBand : Singleton<WorldBand>
{
    public List<BandObject> bandObjects;
    public void registerBandObject(BandObject bandObject)
    {
        bandObjects.Add(bandObject);
    }

    public void removeBandObject(BandObject bandObject)
    {
        bandObjects.Remove(bandObject);
    }

}
