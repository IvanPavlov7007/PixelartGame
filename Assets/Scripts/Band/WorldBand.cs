using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class WorldBand : Singleton<WorldBand>
{

    public List<BandObject> bandObjects = new List<BandObject>();

    public void initializeBandObjects()
    {
        var bandObjectsInScene = FindObjectsOfType<BandObject>();
        foreach(var bo in bandObjectsInScene)
        {
            registerBandObject(bo);
        }
    }

    public void UpdateLogic()
    {
        foreach (var obj in bandObjects)
        {
            obj.UpdateLogic();
        }
    }

    public void registerBandObject(BandObject bandObject)
    {
        if(bandObjects.Contains(bandObject))
        {
            Debug.LogWarning(bandObject.name + " is already registered as a band object");
            return;
        }
        bandObjects.Add(bandObject);
        bandObject.onDestroyed += onBandObjectDestryoed;
    }

    public void removeBandObject(BandObject bandObject)
    {
        if (!bandObjects.Contains(bandObject))
        {
            Debug.LogError(bandObject.name + " is not registered as a band object");
            return;
        }
        bandObjects.Remove(bandObject);
    }

    private void onBandObjectDestryoed(BandObject bandObject)
    {
        removeBandObject(bandObject);
    }

    /// <summary>
    /// Don't use it unless from Game Manager
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
    public BandObject spawnNewBandObject(GameObject prefab)
    {
        BandObject bandObject;
        var go = Instantiate(prefab, transform);
        bandObject = GetComponent<BandObject>();
        if(bandObject == null)
        {
            Debug.LogError(prefab.ToString() + "doesnt have any BandObject components");
            Destroy(bandObject);
            return null;
        }
        return bandObject;
    }
}
