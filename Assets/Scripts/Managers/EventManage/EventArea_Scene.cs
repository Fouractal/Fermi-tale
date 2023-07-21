using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventArea_Scene : MonoBehaviour
{
    private void Awake()
    {
        AreaEventData areaEventData = new AreaEventData(Vector3.zero, 3, ()=> Debug.Log("Hello!"));
        EventManager.Instance.AddAreaEvent(areaEventData);
    }
}
