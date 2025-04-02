using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedingStoryManager : MonoBehaviour
{
    public SideView sideView;
    public View dashboardView;
    public TopView topView;
    public HeartView heartView;
    public GameObject ControlsHint;
    public GameObject EndingHint;
    public AudioSource audioSource;
    public GameObject[] objectsToDisable;
    public AudioClip hitClip;

    public float showTopViewDistance = 80f;
    public float showHeartViewSpeed = 7f;
    public float hideHeartViewSpeed = 2f;
    public float showDashboardViewSpeed = 1f;
    public float endingSpeed = 9.99f;
    public float hideControlsSpeed = 1f;
    public float endingHintTime = 3f;

    bool endingTriggered = false;
    bool endingShowed = false;
    private void Update()
    {
        var speed = GameManager.Instance.speedController.currentSpeed;
        var position = GameManager.Instance.currentScenePosition;

        if (position > showTopViewDistance)
            topView.Show();
        if (speed >= showHeartViewSpeed)
            heartView.Show();
        if (speed < hideHeartViewSpeed)
            heartView.Hide();
        if (speed >= showDashboardViewSpeed)
            dashboardView.Show();
        if (speed >= hideControlsSpeed)
            ControlsHint.SetActive(false);

        if (!endingShowed && speed >= endingSpeed)
        {
            endingShowed = true;
            foreach (var ob in objectsToDisable)
            {
                ob.SetActive(false);
            }
            audioSource.PlayOneShot(hitClip,1f);
            Run.After(endingHintTime, () => EndingHint.SetActive(true));
        }
    }
}
