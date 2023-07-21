using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WarningEvent : MonoBehaviour
{
    // Player를 감지해야 하는 오브젝트, 감지하는 코드를 오브젝트에 직접 대입함. 
    // 오브젝트마다 감지할 거리가 다를 수 있기 때문. 이건 자식에 플레이어 감지용 콜라이더 생성 -> isTrigger On

    private Material _material;
    
    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        Debug.Log(_material);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Detected!");
            DetectedEvent();
        }

        
    }

    private void DetectedEvent()
    {
        _material.DOColor(Color.black, 2f);
    }
}
