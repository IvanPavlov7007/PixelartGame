using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ParallaxHint : MonoBehaviour
{
    public float parallax = 10f;
    public float screenWorldDistance;

    public Vector3 offset;
    public Color colorLine = Color.yellow;
    public float verticalsHight = 0.2f;
}

[CanEditMultipleObjects]
[CustomEditor(typeof(ParallaxHint))]
public class ParallaxHintEditor : Editor
{
    private void OnSceneGUI()
    {
        foreach (var t in Selection.gameObjects)
        {
            var hint = t.GetComponent<ParallaxHint>();
            if (hint == null)
                continue;

            Handles.color = hint.colorLine;

            Vector3 worldPos = hint.transform.position + hint.offset;
            Vector3 left = worldPos + Vector3.left * hint.parallax;
            Vector3 right = worldPos + Vector3.right * hint.parallax;
            Handles.DrawLine(left, right);
            drawVerticalLines(left, hint.verticalsHight);
            drawVerticalLines(right, hint.verticalsHight);
        }
    }

    private void drawVerticalLines(Vector3 center, float hight)
    {
        Vector3 up = center + Vector3.up * hight;
        Vector3 down = center + Vector3.down * hight;

        Handles.DrawLine(down, up);
    }
}