using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{
    public static Image image;
    public static Sequence overlaySequence;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public static void FadeOut()
    {
        if (overlaySequence.IsActive()) return;

        overlaySequence = DOTween.Sequence()
            .Append(image.DOFade(1f, 2f));
    }

    public static void FadeIn()
    {
        if (overlaySequence.IsActive()) return;

        overlaySequence = DOTween.Sequence()
            .Append(image.DOFade(0f, 2f));
    }
}
