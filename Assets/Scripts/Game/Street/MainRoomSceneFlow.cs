using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MainRoomSceneFlow : SceneFlow
{
    [SerializeField] private MovementUserGuide movementUserGuide;
    [SerializeField] private RotationUserGuide rotationUserGuide;
    [SerializeField] private InteractionUserGuide interactionUserGuide;
    
    
    public Define.MainRoom_Phase Phase { get; set; }

    private void Awake()
    {
        GameManager.Instance.SceneFlow = this;
    }

    private void Start()
    {
        Phase = Define.MainRoom_Phase.Start;

        StartCoroutine(GameFramework());
    }
    
    
    private IEnumerator GameFramework()
    {
        // TODO : 사용법 안내 Fade In, Out
        yield return new WaitForSeconds(5);
        Phase = Define.MainRoom_Phase.MovementGuide;
        
        // Phase와 Is Guide Completed를 함께 검사할 필요가 있나? (고민)
        yield return new WaitUntil(() => Phase == Define.MainRoom_Phase.MovementGuide);
        movementUserGuide.InitializeGuide();
        movementUserGuide.ShowInstructions(); // Movement User Guide 시작 (Instruction)
        movementUserGuide.PlayEffect(); // 연출 효과 실행(반복 실행 루틴)

        yield return new WaitUntil(() => (movementUserGuide.CheckIsGuideCompleted()));
        movementUserGuide.StopEffect(); // 이전 연출 중단
        rotationUserGuide.InitializeGuide();
        rotationUserGuide.ShowInstructions(); // Rotation User Guide 시작 (Instruction)
        rotationUserGuide.PlayEffect(); // 연출 효과 실행(반복 실행 루틴)


        yield return new WaitUntil(() => (rotationUserGuide.CheckIsGuideCompleted()));
        rotationUserGuide.StopEffect(); // 이전 연출 중단
        interactionUserGuide.InitializeGuide();
        interactionUserGuide.ShowInstructions(); // interaction User Guide 시작 (Instruction)
        interactionUserGuide.PlayEffect(); // 연출 효과 실행(반복 실행 루틴)

        yield return new WaitUntil(() => (interactionUserGuide.CheckIsGuideCompleted()));
        // TODO : 자연스럽게 문 밖으로 나가게 유도하기? 어떻게?
    }
}
