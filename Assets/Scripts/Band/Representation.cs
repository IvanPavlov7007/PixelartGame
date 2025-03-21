using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Representation : MonoBehaviour
{
    public BandObject bandObject;
    public abstract void Draw(float bandPosition);

    public event Action<Representation> onDisabled;
    public event Action<Representation> onEnabled;

    private void OnEnable()
    {
        onEnabled?.Invoke(this);
    }

    private void OnDisable()
    {
        onDisabled?.Invoke(this);
    }
}


public class ViewData
{
    public Transform centerOfCoordinates;
}