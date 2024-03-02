using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private TouchPad touchPad;

    private Vector2 startPos;       // 시작점 위치
    private Vector2 endPos;         // 끝점 위치
    private Vector2 direction;      // 계산한 방향
    private Vector2 originalVector;
    private float _moveBlendValue;

    public void Start()
    {
        player = PlayerCharacterManager.Instance.player;
        touchPad = TouchPad.Instance;
        
        touchPad.drag.OnDragStart += PosMark;
        touchPad.drag.OnWhileDrag += CharacterMove;
        touchPad.drag.OnDragDone += AfterInteraction;
        touchPad.longPress.OnLongPress += TryInteraction;
        touchPad.longPress.OnLongPress += Haptic;
    }
    

    private void PosMark(PointerEventData eventData)
    {
        // 시작점 기억
        startPos = eventData.position;
    }

    private void CharacterMove(PointerEventData eventData)
    {
        // 플레이어가 이동할 "방향" 업데이트
        endPos = eventData.position;
        // JoyStick 터치 길이에 따른 Move Blend Tree 값 변경, (Idle <-> Walk <-> Run)
        //임의로 20만을 Blend Tree 최댓값으로 설정.
        
        originalVector = (endPos - startPos).normalized;

        switch (CinemachineVirtualCamManager.Instance.cameraTurnController.cameraDirection)
        { 
            case(Define.CameraDirection.NE):
                player.direction = originalVector;
                break;
            case (Define.CameraDirection.NW):
                player.direction.x = -originalVector.y;
                player.direction.y = originalVector.x;
                break;
            case(Define.CameraDirection.SE):
                player.direction.x = originalVector.y;
                player.direction.y = -originalVector.x;
                break;
            case(Define.CameraDirection.SW):
                player.direction.x = -originalVector.x;
                player.direction.y = -originalVector.y;
                break;
        }

        Debug.Log($"x diff : {Mathf.Abs(endPos.x - startPos.x)}, y diff : {Mathf.Abs(endPos.y - startPos.y)}");
        float value = 40f;
        if (Mathf.Abs(endPos.x - startPos.x) < value && Mathf.Abs(endPos.y - startPos.y) < value) player.direction = Vector2.zero;
            // Debug.Log($"_moveBlendValue : {_moveBlendValue}, x distance : {endPos.x - startPos.x}, y distance : {endPos.y - startPos.y}");
        _moveBlendValue = (Mathf.Abs(Mathf.Pow(endPos.x - startPos.x, 2)
                                     + Mathf.Pow(endPos.y - startPos.y, 2))) / 100000f;
        if (_moveBlendValue < 0.01) _moveBlendValue = 0;
        if (_moveBlendValue > 0.5) player.speed = 1.1f;
        else player.speed = 0.7f;
        player.playerAnimator.applyRootMotion = false;
        player.playerAnimator.SetFloat("MoveBlend", _moveBlendValue);
        //_playerController.playerAnimator.SetBool("IsWalking",true);
    }

    private void AfterInteraction(PointerEventData eventData)
    {
        // 이동 종료시 direction 제거
        player.direction = Vector2.zero;
        _moveBlendValue = 0f;
        player.playerAnimator.applyRootMotion = true;
        player.playerAnimator.SetFloat("MoveBlend", _moveBlendValue);
        //_playerController.playerAnimator.SetBool("IsWalking",false);
    }

    private void TryInteraction(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit raycastHit;
        
        if (Physics.Raycast(ray, out raycastHit, 100f, LayerMask.GetMask("Object")))
        {
            raycastHit.collider.GetComponent<IInteractable>()?.Interaction();
        }
    }

    private void Haptic(PointerEventData eventData)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidUtils.Vibrate(20);
#else
        Handheld.Vibrate();
#endif
    }
}
