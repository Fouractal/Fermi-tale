using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EventArea : MonoBehaviour
{
    public AreaEventData areaEventData;
    private BoxCollider _boxCollider;
    
    private void Awake()
    {
        areaEventData.eventArea = this;
        _boxCollider = GetComponent<BoxCollider>();
    }
    
    public void InitAreaEventData(AreaEventData data)
    {
        areaEventData = data;
        transform.position = this.areaEventData.areaPos;
#if DEVELOPMENT_BUILD
        transform.localScale = new Vector3(areaEventData.areaSize, 1, areaEventData.areaSize);
#endif
        
#if !DEVELOPMENT_BUILD
        //_boxCollider.size = new Vector3(areaEventData.areaSize, 1, areaEventData.areaSize);
        transform.localScale = new Vector3(areaEventData.areaSize, 1, areaEventData.areaSize);
#endif
    }

    private void OnTriggerEnter(Collider other)
    {
        if (areaEventData.maxExecuteCount <= areaEventData.curExecuteCount && areaEventData.maxExecuteCount != -1 ) return;
        if (!other.CompareTag("Player")) return;
        areaEventData.func();
        areaEventData.curExecuteCount++;
    }
}
