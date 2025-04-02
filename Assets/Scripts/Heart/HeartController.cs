using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    float bps = 1f;
    public float beatsPerSecond { 
        get { return bps; }
        set { bps = value; applyBps(bps); } }

    private void applyBps(float bps)
    {
        anim.speed = bps;
    }

    public void Play()
    {
        applyBps(bps);
    }

    public void Stop()
    {
        anim.speed = 0f;
    }
}
