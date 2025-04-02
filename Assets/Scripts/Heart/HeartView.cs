using System.Collections;
using UnityEngine;

public class HeartView : View
{
    [SerializeField]
    HeartController heartController;

    private void Start()
    {
        heartController.Stop();
    }

    private void stop(float delay)
    {
        Run.After(delay, ()=>heartController.Stop());
    }

    public override void Hide(float delay = 0f)
    {
        base.Hide(delay);
        stop(delay);
    }

    public override void HideFast(float delay = 0f)
    {
        base.HideFast();
        stop(delay);
    }

    public override void Show(float delay = 0)
    {
        base.Show(delay);
        heartController.Play();
    }

    private void Update()
    {
        if (showed)
            heartController.beatsPerSecond = GameManager.Instance.speedController.currentSpeed * 0.6f;
    }
}