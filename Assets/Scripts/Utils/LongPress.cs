using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class LongPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public delegate void PressHandler(PointerEventData eventData);

    public event PressHandler OnLongPress;

    public float pressTimeThreshold;
    public float pressDistThreshold;

    private Vector3 _posMark;
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
        _posMark = eventData.position;
        
        yield return new WaitForSecondsRealtime(pressTimeThreshold);
        
        if (Vector3.Distance(_posMark, eventData.position) < pressDistThreshold)
        {
            OnLongPress?.Invoke(eventData);
        }
    }
}