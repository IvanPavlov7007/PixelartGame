using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField]
    protected Curtain curtain;
    protected bool showed = false;

    public virtual void Hide(float delay = 0f)
    {
        if (!showed)
            return;
        showed = false;
        curtain.Hide(1f, delay);
    }

    public virtual void HideFast(float delay = 0f)
    {
        if (!showed)
            return;
        showed = false;
        curtain.Hide(0f, delay);
    }

    public virtual void Show(float delay = 0f)
    {
        if (showed)
            return;
        showed = true;
        curtain.Show(1f, delay);
    }

    public virtual void ShowFast(float delay = 0f)
    {
        if (showed)
            return;
        showed = true;
        curtain.Show(0f, delay);
    }
}
