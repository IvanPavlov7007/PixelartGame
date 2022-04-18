using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScrollerStage : MonoBehaviour
{
    //Input for the next "run"
    public Vector2 maxScrollDistance;
    public float speed;
    public float triggerNextStageDistance;
    public Transform offset_leftBottom;
    public event System.Action triggerNextStage;


    //Current "run" variablies
    protected Transform current_Offset_leftBottom;
    protected Vector2 current_maxScrollDistance;
    protected float current_triggerNextStageDistance;
    protected Vector2 scrolledDistance;
    protected bool nextStageTriggered, atTheEnd;


    private void Awake()
    {
        Reset();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        if (atTheEnd)
            return;
        scrolledDistance += current_maxScrollDistance.normalized * Time.deltaTime * speed;
        Vector2 dif = current_maxScrollDistance - scrolledDistance;
        if(!nextStageTriggered && dif.magnitude < current_triggerNextStageDistance)
        {
            TriggerNextStage();
        }

        if (Vector2.Dot(scrolledDistance, dif) < 0f)
        {
            atTheEnd = true;
        }
        var pos = (Vector2)current_Offset_leftBottom.position + scrolledDistance;
        transform.position = new Vector2(CommonTools.truncateFloat(pos.x), pos.y);
    }

    public void Reset()
    {
        scrolledDistance = Vector2.zero;
        nextStageTriggered = false;
        atTheEnd = false;
        current_Offset_leftBottom = offset_leftBottom;
        current_maxScrollDistance = maxScrollDistance;
        current_triggerNextStageDistance = triggerNextStageDistance;
        Update();
    }
    public void CopyValues(ScrollerStage c)
    {
        offset_leftBottom = c.offset_leftBottom;
        triggerNextStageDistance = c.triggerNextStageDistance;
        maxScrollDistance = c.maxScrollDistance;
    }

    public void TriggerNextStage()
    {
        nextStageTriggered = true;
        if (triggerNextStage != null) triggerNextStage();
    }
}
