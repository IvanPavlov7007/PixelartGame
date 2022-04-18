using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class CurrentScrollerState : MonoBehaviour
{
    ScrollerStage stage;
    protected StateMachine stateMachine;

    private void Start()
    {
        stateMachine = GetComponentInParent<StateMachine>();
        stage = GetComponentInChildren<ScrollerStage>();
        stage.transform.parent = null;
        stage.triggerNextStage += TriggerNextStage;
    }

    private void OnEnable()
    {
        if(stage != null)
            stage.Reset();
    }

    private void OnDisable()
    {
        
    }

    public void TriggerNextStage()
    {
        if (stateMachine.AtLast)
            stateMachine.ChangeState(0);
        else
            stateMachine.Next();
    }
}
