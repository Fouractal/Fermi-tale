using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickUICanvas : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;
    
    [SerializeField]
    private Image dragPanel;
    [SerializeField]
    private Dragable dragable;

    private Vector2 startPos;       // 시작점 위치
    private Vector2 endPos;         // 끝점 위치

    private Vector2 direction;      // 계산한 방향

    private void Awake()
    {
        _playerController = PlayerCharacterManager.Instance.playerController;
        
        dragPanel = GetComponentInChildren<Image>();
        
        dragable = GetComponentInChildren<Dragable>();
        dragable.OnDragStart += PosMark;
        dragable.OnWhileDrag += CharacterMove;
        dragable.OnDragDone += AfterInteraction;
    }

    private void PosMark(PointerEventData eventData)
    {
        // 시작점 기억
        Debug.Log($"PosMark");
        startPos = eventData.position;
        
    }

    private void CharacterMove(PointerEventData eventData)
    {
        // 플레이어가 이동할 "방향" 업데이트
        //Debug.Log($"CharacterMove");
        endPos = eventData.position;
        _playerController.direction = (endPos - startPos).normalized;
        _playerController.playerAnimator.SetBool("IsWalking",true);
        Debug.Log(_playerController.direction);
    }

    private void AfterInteraction(PointerEventData eventData)
    {
        // 이동 종료시 direction 제거
        Debug.Log($"AfterInteraction");
        _playerController.direction = Vector2.zero;
        _playerController.playerAnimator.SetBool("IsWalking",false);
    }
}
