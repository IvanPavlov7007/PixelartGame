using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float currentSceneSpeed = 1.6f;

    private void Update()
    {
        WorldBand.Instance.TranslateScene(currentSceneSpeed * Time.deltaTime);
        WorldBand.Instance.UpdateScene();
    }
}
