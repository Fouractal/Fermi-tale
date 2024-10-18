using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementUserGuide : BaseInteractive
{
    private TouchPad _touchPad;
    private bool _isCompleted = false;
    [SerializeField] private TextMeshProUGUI instructionText;
    
    [Header("Variable (Effect)")]
    private Tweener _moveTweener;          // DOPath 애니메이션을 저장할 변수
    [SerializeField] private RectTransform circleImage; // Circle 이미지 (RectTransform)
    public RectTransform pointAObject;    // 시작 지점의 RectTransform 오브젝트
    public RectTransform pointBObject;    // 끝 지점의 RectTransform 오브젝트
    public float moveDuration = 2f;   // 이동 시간
    
    public override void InitializeGuide()
    {
        circleImage.parent.gameObject.SetActive(true);

        // touchPad 이벤트 추가 
        _touchPad = TouchPad.Instance;
        _touchPad.drag.OnDragDone += SetDragComplete;
    }
    
    // 텍스트로 이동 방법을 알려준다.
    public override void ShowInstructions()
    {
        // Instruction 텍스트 초기화
        instructionText.alpha = 0;
        instructionText.text = "드래그해서 플레이어를 움직여 보세요!";
        
        // 글자 Fade In
        instructionText.DOFade(1, 2);
    }

    public override void PlayEffect()
    {
        // Image 이동 루틴
        
        // TODO : 이미지를 곡선(비선형)을 따라 움직임. 빠르게 샥 움직였다가 FadeOut, 다시 처음 위치에서 움직임 시작

        circleImage.GetComponent<Image>().DOFade(1, 0.1f);

        Vector3 pointA = pointAObject.position;
        Vector3 pointB = pointBObject.position;
        
        // 곡선의 중간 지점을 계산하여 경로를 만들기 위한 제어 포인트
        Vector3 controlPoint = (pointA + pointB) / 2 + new Vector3(0, 50f, 0); // 중간에 약간 위로 올림

        // 경로 설정: A -> Control Point -> B
        Vector3[] pathPoints = new Vector3[] { pointA, controlPoint, pointB };

        // Circle 이미지를 경로를 따라 곡선 이동
        circleImage.position = pointA;  // 시작 지점에서 시작
        _moveTweener = circleImage.DOPath(pathPoints, moveDuration, PathType.CatmullRom)
            .SetEase(Ease.InOutSine).OnComplete(  // 부드러운 곡선 이동
                (() => circleImage.GetComponent<Image>().DOFade(0,1f).OnComplete(
                    () => PlayEffect())));
    }
    
    // 성공적으로 가이드를 따랐을 경우에 효과를 끈다.
    [ContextMenu("Stop Effect")]
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
        circleImage.parent.gameObject.SetActive(false);
    }
    
    // 유저가 드래그를 했는가를 검사한다. (실제로 드래그를 감지해? 야매로 플레이어 위치 변화를 감지해?)
    public override bool CheckIsGuideCompleted()
    {
        return _isCompleted;
    }
    public void SetDragComplete(PointerEventData eventData)
    {
        _isCompleted = true;
        _touchPad.drag.OnDragDone -= SetDragComplete;
    }
}
