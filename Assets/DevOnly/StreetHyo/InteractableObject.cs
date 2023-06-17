using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public delegate void InteractEventHandler();
    public event InteractEventHandler OnInteract;

    
    public delegate IEnumerator MoveEventHandler();
    public event MoveEventHandler OnMove;

    private void Start()
    {
        // StartCoroutine(StartMove());
    }

    private IEnumerator StartMove()
    {
        // OnMove 이벤트 핸들러 호출, OnMove의 이벤트 핸들러의 실행이 끝날 때까지 기다림.
        yield return StartCoroutine(OnMove?.Invoke());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 이벤트 발생, OnInteract 이벤트가 null이 아닌 경우에만 Invoke() 호출
            OnInteract?.Invoke();
        }
    }
}
