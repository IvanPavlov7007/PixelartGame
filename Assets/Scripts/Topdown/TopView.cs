using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopView : View
{
    public Camera cam;
    public RepresentatorTop representatorTop;

    private void Start()
    {
    }

    public void drawScene(float bandPosition)
    {
        representatorTop.currentBandPosition = bandPosition;
        representatorTop.DrawScene();
    }
}
