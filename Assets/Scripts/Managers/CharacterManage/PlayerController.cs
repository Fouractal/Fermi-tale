using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController
{
    [SerializeField]
    private Player player;
    private Vector2 startDragPos;       // 시작점 위치
    private Vector2 curDragPos;         // 끝점 위치

    [SerializeField]
    private int maxDragLen = 400;
    [SerializeField]
    private int minDragLen = 40;

    public PlayerController(Player player)
    {
        this.player = player;
    }

    public void PosMark(PointerEventData eventData)
    {
        startDragPos = eventData.position;
    }

    public void SetPlayerVelocity(PointerEventData eventData)
    {
        curDragPos = eventData.position;
        
        Vector2 screenVector = curDragPos - startDragPos;
        if(screenVector.magnitude > maxDragLen) screenVector = screenVector.normalized * maxDragLen; 
        if(screenVector.magnitude < minDragLen) screenVector = Vector3.zero;

        Vector3 worldVector = Utils.ConvertCoordinateS2W(screenVector);

        switch (CameraManager.Instance.cameraTurnController.cameraDirection)
        { 
            case Define.CameraDirection.NE:
                worldVector = worldVector;
                break;
            case Define.CameraDirection.NW:
                worldVector = new Vector3(-worldVector.z, 0f, worldVector.x);
                break;
            case Define.CameraDirection.SE:
                worldVector = new Vector3(worldVector.z, 0f, -worldVector.x);
                break;
            case Define.CameraDirection.SW:
                worldVector = -worldVector;
                break;
        }
        
        Vector3 velocity = worldVector / maxDragLen * 5f;   // TODO : worldVector / maxDragLen * maxPlayerSpeed
        player.SetVelocity(velocity);

        float moveBlendValue = worldVector.magnitude / maxDragLen;
        player.MoveBlend(moveBlendValue);
    }

    public void ResetPlayerVelocity(PointerEventData eventData)
    {
        player.SetVelocity(Vector3.zero);
        player.MoveBlend(0f);
    }

    public void TryInteraction(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit raycastHit;
        
        if (Physics.Raycast(ray, out raycastHit, 100f, LayerMask.GetMask("Object")))
        {
            IInteractable target = raycastHit.collider.GetComponent<IInteractable>();
            player.Interaction(target);
        }
    }
}
