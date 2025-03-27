using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Speedometer : MonoBehaviour
{
    public Transform leftDirection;
    public Transform rightDirection;
    public float maxUnclampedT;
    public float t;

    [SerializeField]
    LineRenderer lineRenderer;

    private void LateUpdate()
    {
        lineRenderer.SetPosition(1, currentDirection());
    }

    public Vector3 currentDirection()
    {
        // Compute the full arc angle (from left to right via the long path)
        float angle = Vector3.Angle(leftDirection.localPosition, rightDirection.localPosition);
        float tMax = 360f / angle - 1f; // Compute the correct t_max for full arc traversal

        // Scale t so that t=1 reaches rightDirection in the long arc
        float longArcT = -t * tMax;

        return Vector3.SlerpUnclamped(leftDirection.localPosition, rightDirection.localPosition, longArcT);
    }
}
