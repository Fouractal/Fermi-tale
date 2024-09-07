using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private DoorEvent doorEvent;
    
    public void Interaction()
    {
        Debug.Log("RoseInteraction");
        if(!doorEvent.isTriggered) return;
        else
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        transform.DOLocalRotate(new Vector3(-90, 0, -90), 2, RotateMode.Fast);
    }
}
