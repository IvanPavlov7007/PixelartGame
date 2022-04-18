using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    public int frameRate = 12;
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRate;
    }
}
