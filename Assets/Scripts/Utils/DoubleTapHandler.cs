using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleTapHandler : MonoBehaviour, IPointerDownHandler
{
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
}