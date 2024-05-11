using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleTap : MonoBehaviour, IPointerDownHandler
{
    public delegate void TapHandler(PointerEventData eventData);
    public event TapHandler OnDoubleTap;
    
    public float doubleTapInterval;

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
            _intervalCheckRoutine = StartCoroutine(IntervalCheckRoutine());
        }
    }

    private IEnumerator IntervalCheckRoutine()
    {
        yield return new WaitForSecondsRealtime(doubleTapInterval);
        _isAlreadyTap = false;
    }
}