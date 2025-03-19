using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class WorldBand : Singleton<WorldBand>
{
    public float currentScenePosition = 0f;

    public List<BandObject> bandObjects;

    public void UpdateScene()
    {
        foreach (var b in bandObjects)
        {
            b.UpdateWorldPosition(currentScenePosition);
        }
    }

    public void registerBandObject(BandObject bandObject)
    {
        bandObjects.Add(bandObject);
    }

    public void removeBandObject(BandObject bandObject)
    {
        bandObjects.Remove(bandObject);
    }

    public void TranslateScene(float delta)
    {
        MoveScene(currentScenePosition + delta);
    }

    public void MoveScene(float newPosition)
    {
        currentScenePosition = newPosition;
    }

}
