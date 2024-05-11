using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour
{
    public static TouchPad Instance;

    public Drag drag;
    public DoubleTap doubleTap;
    public LongPress longPress;
    
    private void Awake()
    {
        Instance = this;
        drag = GetComponent<Drag>();
        doubleTap = GetComponent<DoubleTap>();
        longPress = GetComponent<LongPress>();
    }
}