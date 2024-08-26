using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Coroutine timerRoutine;
    
    public delegate void TimerHandler();
    public event TimerHandler OnTimeOver;
    public event TimerHandler OnNextTimeOver;

    public void StartTimer(float time, bool repeat = false)
    {
        if (timerRoutine != null) return;
        
        timerRoutine = StartCoroutine(TimerRoutine(time, repeat));
    }

    private IEnumerator TimerRoutine(float time, bool repeat)
    {
        do
        {
            yield return new WaitForSecondsRealtime(time);
            OnTimeOver?.Invoke();
            OnNextTimeOver?.Invoke();
            OnNextTimeOver = null;
        }
        while (repeat);
    }

    public void StopTimer()
    {
        StopCoroutine(timerRoutine);
        timerRoutine = null;
    }
}
