using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInfoSender : MonoBehaviour
{
    public BlackObjectController blackObjectController;

    // Player 감지 시 Black Obj 추적 시작
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(blackObjectController.ChasingPlayer(other.transform));
        }
    }
}