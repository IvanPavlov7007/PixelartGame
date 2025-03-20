using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Representator : MonoBehaviour
{
    public float currentBandPosition = 0f;

    public abstract  IEnumerable<Representation> representations { get; }

    public virtual void DrawScene()
    {
        foreach(var rep in representations)
        {
            rep.Draw(currentBandPosition);
        }
    }
}
