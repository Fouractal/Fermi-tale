using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickUICanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    
    [SerializeField]
    private Image dragPanel;
    [SerializeField]
    private Dragable dragable;
    

    private void Awake()
    {
        dragPanel = GetComponentInChildren<Image>();
        
        dragable = GetComponentInChildren<Dragable>();
        dragable.OnDragStart += PosMark;
        dragable.OnWhileDrag += CharacterMove;
        dragable.OnDragDone += AfterInteraction;
    }

    private void PosMark(PointerEventData eventData)
    {
        Debug.Log($"PosMark");
    }

    private void CharacterMove(PointerEventData eventData)
    {
        Debug.Log($"CharacterMove");
    }

    private void AfterInteraction(PointerEventData eventData)
    {
        Debug.Log($"AfterInteraction");
    }
}
