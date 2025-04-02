using System.Collections;
using UnityEngine;
using Pixelplacement;

public class Curtain : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    public void Show(float duration, float delay)
    {
        Tween.Color(spriteRenderer, Color.clear, duration, delay);
    }

    public void Hide(float duration, float delay)
    {
        Tween.Color(spriteRenderer, Color.black, duration, delay);
    }
}