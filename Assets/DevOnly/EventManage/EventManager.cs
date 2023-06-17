using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    #region Time Event
    private Coroutine timeEventRoutine;
    
    public Queue<TimeEventData> timeEventQueue = new Queue<TimeEventData>();        // 추후 우선순위 큐로 수정
    
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
            yield return new WaitForSeconds(1f);    // 이벤트를 1초 단위로 확인하여 실행시킨다.
            curTime += Time.deltaTime;

            while (timeEventQueue.Peek().eventTiming < curTime)
            {
                TimeEventData targetEvent = timeEventQueue.Dequeue();
                targetEvent.targetAction();
            }
        }
    }
    
    public void AddTimeEvent(float timing, Action action)
    {
        TimeEventData newEventData = new TimeEventData();
        newEventData.eventTiming = timing;
        newEventData.targetAction = action;
        
        timeEventQueue.Enqueue(newEventData);
    }
    #endregion

    #region Area Event

    public List<AreaEventData> areaEventList = new List<AreaEventData>();

    public void AddAreaEvent(AreaEventData areaEventData)
    {
        GameObject eventAreaPrefab = Resources.Load<GameObject>("Prefabs/EventArea");
        EventArea newEventArea = Instantiate(eventAreaPrefab).GetComponent<EventArea>();
        newEventArea.InitAreaEventData(areaEventData);

        areaEventList.Add(areaEventData);
    }

    #endregion
}
