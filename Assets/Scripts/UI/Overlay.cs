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

    public static void FadeOut(Define.FadeType fadeType = Define.FadeType.Black)
    {
        if (overlaySequence.IsActive()) return;
        
        switch (fadeType)
        {
            case Define.FadeType.Black:
                image.color = new Color(0,0,0,0);
                break;
            case Define.FadeType.White:
                image.color = new Color(1,1,1,0);
                break;
        }

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
