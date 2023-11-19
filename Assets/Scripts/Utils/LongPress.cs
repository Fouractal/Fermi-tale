using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class LongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public delegate void PressHandler(PointerEventData eventData);

    public event PressHandler OnLongPress;

    public float pressThreshold;

    private Coroutine _pressCheckRoutine = null;

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressCheckRoutine = StartCoroutine(PressCheckRoutine(eventData));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopCoroutine(_pressCheckRoutine);
    }

    private IEnumerator PressCheckRoutine(PointerEventData eventData)
    {
        yield return new WaitForSecondsRealtime(pressThreshold);
        OnLongPress?.Invoke(eventData);
    }
}