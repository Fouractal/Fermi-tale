using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    private Coroutine timeEventRoutine;
    
    public Queue<TimeEventData> eventQueue = new Queue<TimeEventData>();        // 추후 우선순위 큐로 수정

    public void StartTimeEventRoutine()
    {
        if(timeEventRoutine != null) StopCoroutine(timeEventRoutine);
        timeEventRoutine = StartCoroutine(TimeEventRoutine());
    }
    
    private IEnumerator TimeEventRoutine() 
    {
        float curTime = 0f;                         // 게임이 진행된 시간
        
        while (true)
        {
            yield return new WaitForSeconds(1f);    // 이벤트를 1초마다 확인하여 실행시킨다.
            curTime += Time.deltaTime;

            while (eventQueue.Peek().eventTiming < curTime)
            {
                TimeEventData targetEvent = eventQueue.Dequeue();
                targetEvent.targetAction();
            }
        }
    }
    
    public void AddTimeEvent(float timing, Action action)   // 이벤트 등록 1안 : 외부 스크립트에서 원하는 이벤트를 등록할 수 있게 처리한다.
    {
        TimeEventData newEventData = new TimeEventData();
        newEventData.eventTiming = timing;
        newEventData.targetAction = action;
        
        eventQueue.Enqueue(newEventData);
    }

    public void EventSetter()                               // 이벤트 등록 2안 : 모든 TimeEvent는 아래에서 미리 세팅하여 한눈에 볼 수 있게한다.
    {
        Event1 event1 = new Event1();
        AddTimeEvent(32f, event1.MoveCircle);
    }
    
}
