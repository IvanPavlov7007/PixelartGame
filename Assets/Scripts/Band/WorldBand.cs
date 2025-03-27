using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class WorldBand : Singleton<WorldBand>
{

    public List<BandObject> bandObjects = new List<BandObject>();
    public List<BandObjectCollision> collisions = new List<BandObjectCollision>();

    public void initializeBandObjects()
    {
        var bandObjectsInScene = FindObjectsOfType<BandObject>();
        foreach(var bo in bandObjectsInScene)
        {
            registerBandObject(bo);
        }
    }

    public void UpdateLogic(float scenePosition)
    {
        foreach (var obj in bandObjects)
        {
            obj.UpdateLogic(scenePosition);
        }
    }

    public void CheckCollisions(float scenePosition)
    {
        foreach (var col in collisions)
        {
            col.CheckCollisions();
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

        findCollision(bandObject);
    }

    public void removeBandObject(BandObject bandObject)
    {
        if (!bandObjects.Contains(bandObject))
        {
            Debug.LogError(bandObject.name + " is not registered as a band object");
            return;
        }
        removeCollision(bandObject);
        bandObjects.Remove(bandObject);
    }


    private void findCollision(BandObject bandObject)
    {
        var collision = bandObject.GetComponent<BandObjectCollision>();
        if (collision != null && !collisions.Contains(collision))
        {
            collisions.Add(collision);
        }
    }

    private void removeCollision(BandObject bandObject)
    {
        var collision = bandObject.GetComponent<BandObjectCollision>();
        if (collision != null && !collisions.Contains(collision))
        {
            collisions.Remove(collision);
        }
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
