using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public delegate void DragHandler(PointerEventData eventData);
    public event DragHandler OnDragStart;
    public event DragHandler OnDragDone;
    public event DragHandler OnWhileDrag;

    public Vector3 startPos = Vector3.zero;
    public Vector3 endPos = Vector3.zero;
    public Vector3 curPos = Vector3.zero;

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnDragStart?.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnDragDone?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnWhileDrag?.Invoke(eventData);
    }
}