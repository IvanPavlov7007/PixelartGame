using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class GameManager : Singleton<GameManager>
{
    public float currentScenePosition = 0f;

    public SpeedController speedController;
    List<RepeatingBandObject> repeatingBandObjects = new List<RepeatingBandObject>();

    public BikeControl bikeControl;
    public TopView topView;
    public SideView sideView;
    public Speedometer speedometer;

    private void Start()
    {
        WorldBand.Instance.initializeBandObjects();
        repeatingBandObjects.AddRange(FindObjectsOfType<RepeatingBandObject>());
        initializeViews();
    }

    private void initializeViews()
    {
        topView.representatorTop.findExistingRepresentationsInScene();
        sideView.representatorSide.findExistingRepresentationsInScene();
        foreach (var obj in WorldBand.Instance.bandObjects)
        {
            registerRepresentationsForBandObject(obj);
        }
    }

    private void Update()
    {
        bikeControl.direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        bikeControl.UpdateInputs();

        currentScenePosition += speedController.calculateCurrentSpeed(bikeControl) * Time.deltaTime;
        bikeControl.UpdateBandObjectPosition(currentScenePosition);
        if (speedometer)
            speedometer.t = speedController.currentSpeed / speedController.maxSpeed;

        logicUpdate();

        if (topView)
            topView.drawScene(currentScenePosition);
        if (sideView)
            sideView.drawScene(currentScenePosition);
    }
    private void logicUpdate()
    {
        WorldBand.Instance.UpdateLogic(currentScenePosition);
        relocateRepeatingObjects();//TODO look the class definition
        WorldBand.Instance.CheckCollisions(currentScenePosition);
    }

    public BandObject SpawnNewBandObject(GameObject prefab)
    {
        var bandObject = WorldBand.Instance.spawnNewBandObject(prefab);
        registerRepresentationsForBandObject(bandObject);
        return bandObject;
    }

    public void registerRepresentationsForBandObject(BandObject bandObject)
    {
        topView.representatorTop.addRepresentedObject(bandObject);
        sideView.representatorSide.addRepresentedObject(bandObject);
    }

    public void DestroyBandObject(BandObject bandObject)
    {
        destroyRepresentationsForBandObject(bandObject);
        Destroy(bandObject);
    }

    public void destroyRepresentationsForBandObject(BandObject bandObject)
    {
        topView.representatorTop.onBandObjectDestroy(bandObject);
        sideView.representatorSide.onBandObjectDestroy(bandObject);
    }

    private void relocateRepeatingObjects()
    {
        foreach(var b in repeatingBandObjects)
        {
            b.updateRepeatingPosition(currentScenePosition);
        }
    }
}
