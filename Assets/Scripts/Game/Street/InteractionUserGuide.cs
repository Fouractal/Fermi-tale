using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractionUserGuide : BaseInteractive
{
    private TouchPad _touchPad;
    private bool _isCompleted = false;
    [SerializeField] private TextMeshProUGUI instructionText;
    
    [Header("Variable (Effect)")]
    private Tweener _moveTweener;          // DOPath 애니메이션을 저장할 변수
    [SerializeField] private Image circleImage; // Circle 이미지 (RectTransform)
    
    public override void InitializeGuide()
    {
        circleImage.gameObject.SetActive(true);

        // touchPad 이벤트 추가 
        _touchPad = TouchPad.Instance;
        _touchPad.longPress.OnLongPress += SetLongPressComplete;
    }
    
    public override void ShowInstructions()
    {
        // Instruction 텍스트 초기화
        instructionText.alpha = 0;
        instructionText.text = "화면에 보이는 물체를 꾹 눌러 상호작용하세요!";
        
        // 글자 Fade In
        instructionText.DOFade(1, 2);
    }

    public override void PlayEffect()
    {
        Vector3 targetScale = new Vector3(2f, 2f, 2f); // 목표 스케일
        Vector3 originScale = Vector3.one;
        
        circleImage.DOFade(1,0.01f);
        circleImage.rectTransform.DOScale(originScale, 0.01f);
        
        _moveTweener = circleImage.rectTransform.DOShakeScale(2f, 0.1f, 10).OnComplete((() => circleImage.rectTransform
            .DOScale(targetScale, 2f).SetEase(Ease.InOutQuad)
            .OnComplete((() => PlayEffect()))));
    }

    public override void StopEffect()
    {
        // DOTween 애니메이션 종료
        if (_moveTweener != null && _moveTweener.IsPlaying())
        {
            _moveTweener.Kill();
        }
        
        // 글자 Fade Out
        instructionText.DOFade(0, 2);
        
        // movement image 비활성화
        circleImage.gameObject.SetActive(false);
    }

    public override bool CheckIsGuideCompleted()
    {
        return _isCompleted;
    }
    public void SetLongPressComplete(PointerEventData eventData)
    {
        _isCompleted = true;
        _touchPad.longPress.OnLongPress -= SetLongPressComplete;
    }
}
