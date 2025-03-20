using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopView : View
{
    public Camera cam;
    public RepresentatorTop representatorTop;

    private void Start()
    {
        //TODO
        //for now we asume there is only one top view, now spawning objects, all objects are predefined in the scene
        //Way to fix: spawn repeating objects, creation should be controlled by a high class that also tracks, creates and assigns representations
        //as well as destruction
        representatorTop.topRepresentations.AddRange(FindObjectsOfType<TopRepresentation>());
    }

    public void drawScene(float bandPosition)
    {
        representatorTop.currentBandPosition = bandPosition;
        representatorTop.DrawScene();
    }
}
