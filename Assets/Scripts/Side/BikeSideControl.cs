using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeSideControl : MonoBehaviour
{
    KeyControl keyControl;

    public float maxLeftPos, maxRightPos;
    public float delta;

    float currentX;

    Vector3 initPos;
    private void Awake()
    {
        initPos = transform.position;
        currentX = initPos.x;
    }

    private void Start()
    {
        keyControl = GetComponent<KeyControl>();
    }


    private void Update()
    {
        if (keyControl.left)
            currentX -= delta;
        if (keyControl.right)
            currentX += delta;

        currentX = Mathf.Clamp(currentX, maxLeftPos, maxRightPos);

        transform.position = new Vector3(currentX, initPos.y, initPos.z);
    }
}
