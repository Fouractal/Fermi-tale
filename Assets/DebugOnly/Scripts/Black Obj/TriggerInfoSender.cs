using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInfoSender : MonoBehaviour
{
    public BlackObject blackObject;

    // Player 감지 시 Black Obj 추적 시작
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(blackObject.ChasingPlayer(other.transform));
        }
    }
}