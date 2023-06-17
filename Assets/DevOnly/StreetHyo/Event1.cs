using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Event1 : MonoBehaviour
{
    public delegate void InteractEventHandler();
    public event InteractEventHandler OnInteract;

    private void Start()
    {
        OnInteract += MoveCircle;
        EventManager.Instance.AddTimeEvent(32f, MoveCircle);
    }

    public void MoveCircle()
    {
        gameObject.transform.position += Vector3.one; 
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}