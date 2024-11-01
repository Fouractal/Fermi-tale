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
            
        yield return new WaitUntil(() => (movementUserGuide.IsCompleted));
        movementUserGuide.StopEffect(); // 이전 연출 중단
        rotationUserGuide.InitializeGuide();
        rotationUserGuide.ShowInstructions(); // Rotation User Guide 시작 (Instruction)
        rotationUserGuide.PlayEffect(); // 연출 효과 실행(반복 실행 루틴)

        yield return new WaitUntil(() => (rotationUserGuide.IsCompleted));
        rotationUserGuide.StopEffect(); // 이전 연출 중단
        interactionUserGuide.InitializeGuide();
        interactionUserGuide.ShowInstructions(); // interaction User Guide 시작 (Instruction)
        interactionUserGuide.PlayEffect(); // 연출 효과 실행(반복 실행 루틴)
        
        yield return new WaitUntil(() => (interactionUserGuide.IsCompleted));
        interactionUserGuide.StopEffect(); // 이전 연출 중단
        SpawnPortal();   
    }
    private void SpawnPortal()
    {
        GameObject portalPrefab = Resources.Load<GameObject>("Prefabs/Portal");
        Transform portalTransform = Instantiate(portalPrefab, new Vector3(2.465f, 1.077f, -0.056f), Quaternion.Euler(0,0,90)).transform;
        portalTransform.localScale = new Vector3(0.3f, 0.15f, 0.15f);

    }
}
