using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RotationUserGuide : BaseInteractive
{
    private TouchPad _touchPad;
    private bool _isCompleted = false;
    [SerializeField] private TextMeshProUGUI instructionText;
    [SerializeField] private Image circleImage;
    private Tweener _moveTweener;          // DOPath 애니메이션을 저장할 변수

    public override void InitializeGuide()
    {
        circleImage.gameObject.SetActive(true);

        // touchPad 이벤트 추가 
        _touchPad = TouchPad.Instance;
        _touchPad.doubleTap.OnDoubleTap += SetDragComplete;
    }
    // 텍스트로 더블탭을 알려준다.
    public override void ShowInstructions()
    {
        // Instruction 텍스트 초기화
        instructionText.alpha = 0;
        instructionText.text = "화면을 두 번 클릭해 카메라를 회전하세요!";
        
        // 글자 Fade In
        instructionText.DOFade(1, 2).OnComplete(
            () => { instructionText.DOFade(0, 2); });
    }
       
    public override void PlayEffect()
    {
        Vector3 targetScale = new Vector3(2f, 2f, 2f); // 목표 스케일
        Vector3 originScale = Vector3.one;
        
        circleImage.GetComponent<Image>().DOFade(1,0.01f);
        circleImage.rectTransform.DOScale(originScale, 0.01f);

        
        // 이미지의 스케일을 애니메이션으로 조
        _moveTweener =  circleImage.rectTransform.DOScale(targetScale, 0.3f).SetEase(Ease.InOutQuad)
            .OnComplete((() => circleImage.rectTransform.DOScale(originScale, 0.01f).SetEase(Ease.InOutQuad)
                .OnComplete((() => circleImage.rectTransform.DOScale(targetScale, 0.6f).SetEase(Ease.InOutQuad)
                    .OnComplete((() => circleImage.GetComponent<Image>().DOFade(0,1f)
                        .OnComplete((() => PlayEffect()))))))));
    }

    public override void StopEffect()
    {
        // DOTween 애니메이션 종료
        if (_moveTweener != null && _moveTweener.IsPlaying())
        {
            _moveTweener.Kill();
        }
            
        // movement image 비활성화
        circleImage.gameObject.SetActive(false);
    }

    
    public override bool CheckIsGuideCompleted()
    {
        return _isCompleted;
    }
    public void SetDragComplete(PointerEventData eventData)
    {
        _isCompleted = true;
    }
    
}
