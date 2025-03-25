using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideView : View
{
    public Camera cam;
    public RepresentatorSide representatorSide;
    public void drawScene(float bandPosition)
    {
        representatorSide.currentBandPosition = bandPosition;
        representatorSide.DrawScene();
    }
}
