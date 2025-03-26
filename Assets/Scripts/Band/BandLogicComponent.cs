using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandLogicComponent : MonoBehaviour
{
    protected virtual void Start()
    {
        GetComponent<BandObject>().onLogicUpdate += logicUpdate;
    }

    private void logicUpdate(BandObject bandObject, float scenePosition)
    {
        if (!enabled)
            return;
        onLogicUpdate(bandObject, scenePosition);
    }

    public virtual void onLogicUpdate(BandObject bandObject, float scenePosition)
    {
    }
}
