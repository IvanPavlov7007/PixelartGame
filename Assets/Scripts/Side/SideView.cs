using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideView : View
{
    public Camera cam;
    public RepresentatorSide representatorSide;

    private void Start()
    {
        //TODO
        //for now we asume there is only one top view, now spawning objects, all objects are predefined in the scene
        //Way to fix: spawn repeating objects, creation should be controlled by a high class that also tracks, creates and assigns representations
        //as well as destruction
        representatorSide.sideRepresentations.AddRange(FindObjectsOfType<SideRepresentation>());
    }

    public void drawScene(float bandPosition)
    {
        representatorSide.currentBandPosition = bandPosition;
        representatorSide.DrawScene();
    }
}
