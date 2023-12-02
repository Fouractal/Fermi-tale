using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ClockHand : MonoBehaviour
{
    private static List<ClockHand> _clockHands = new List<ClockHand>();

    public delegate void OverlapHandler(int overlapCount);
    public static event OverlapHandler OnClockHandsOverlap;
    
    public int overlapCount = 0;

    private void Awake()
    {
        _clockHands.Add(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Friend") || other.CompareTag("ClockHand"))
        {
            overlapCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Friend") || other.CompareTag("ClockHand"))
        {
            overlapCount--;
        }
    }

    public static void CheckClockHandOverlap()
    {
        int maxOverlapCount = 0;
        
        foreach (var clockHand in _clockHands)
        {
            maxOverlapCount = clockHand.overlapCount > maxOverlapCount ? clockHand.overlapCount : maxOverlapCount;
        }
        
        OnClockHandsOverlap?.Invoke(maxOverlapCount);
        Debug.Log($"Invoke : {maxOverlapCount}");
    }
}