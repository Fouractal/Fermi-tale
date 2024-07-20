using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game.FM;
using TMPro;
using UnityEngine;

public class FM_Item : MonoBehaviour
{
    public FM_GameFramework fmGameFramework;
    public FM_Item_Text fmItemText;
    public int itemIndex;
    private void Awake()
    {
        fmItemText = GetComponent<FM_Item_Text>();
        fmItemText.isCollected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(fmItemText.isCollected) return;
        if (other.transform.root.CompareTag("Player"))
            fmGameFramework.Success(itemIndex);

        fmItemText.isCollected = true;
    }
}
