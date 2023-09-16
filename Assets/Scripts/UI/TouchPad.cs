using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    public static TouchPad Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    #region Drag
    public delegate void DragHandler(PointerEventData eventData);
    public event DragHandler OnDragStart;
    public event DragHandler OnDragDone;
    public event DragHandler OnWhileDrag;

    public Vector3 startPos = Vector3.zero;
    public Vector3 endPos = Vector3.zero;
    public Vector3 curPos = Vector3.zero;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(OnDragStart != null)
        {
            eventData.pointerDrag = this.gameObject;
            OnDragStart(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(OnDragDone != null)
        {
            eventData.pointerDrag = this.gameObject;
            OnDragDone(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(OnWhileDrag != null)
        {
            eventData.pointerDrag = this.gameObject;
            OnWhileDrag(eventData);
        }
    }
    #endregion
    
    
    #region DoubleTap
    public float doubleTapInterval;
    public delegate void TapHandler(PointerEventData eventData);
    public event TapHandler OnDoubleTap;

    private bool _isAlreadyTap = false;
    private Coroutine _intervalCheckRoutine = null;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isAlreadyTap)
        {
            StopCoroutine(_intervalCheckRoutine);
            _isAlreadyTap = false;
            OnDoubleTap?.Invoke(eventData);
        }
        else
        {
            _isAlreadyTap = true;
            _intervalCheckRoutine = StartCoroutine(BoolHandleRoutine());
        }
    }

    private IEnumerator BoolHandleRoutine()
    {
        yield return new WaitForSecondsRealtime(doubleTapInterval);
        _isAlreadyTap = false;
    }
    #endregion
}