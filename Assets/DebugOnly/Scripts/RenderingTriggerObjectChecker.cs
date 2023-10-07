using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingTriggerObjectChecker : MonoBehaviour
{
    private RenderingCam _renderingCam;
    void Start()
    {
        _renderingCam = GetComponentInParent<RenderingCam>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trig");
        if (other.gameObject.layer == 30)
        {
            _renderingCam.triggeredGameobject.Add(other.gameObject.GetComponent<RenderingByDirection>());
            other.GetComponent<RenderingByDirection>().isTriggered = true; // 이후 삭제할 내용
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 30)
        {
            _renderingCam.triggeredGameobject.RemoveAt(_renderingCam.triggeredGameobject.IndexOf(other.gameObject.GetComponent<RenderingByDirection>()));
            other.GetComponent<RenderingByDirection>().isTriggered = false;
        }
    }
}
