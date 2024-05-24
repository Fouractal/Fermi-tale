using System;
using System.Collections;
using System.Collections.Generic;
using Game.FM;
using UnityEngine;

public class FM_Item : MonoBehaviour
{
    public Phase itemIndexByPhase;
    public FM_GameFramework fmGameFramework;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (itemIndexByPhase == fmGameFramework.phase))
        {
            fmGameFramework.Success();
        }
    }
}
