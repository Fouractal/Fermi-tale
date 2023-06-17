using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ClippingChecker : Singleton<ClippingChecker>
{
    private void OnTriggerEnter(Collider other)
    {
        ClipObject clipObject = other.transform.GetComponent<ClipObject>();
        
        if (clipObject == null) return;
        clipObject.IsInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        ClipObject clipObject = other.transform.GetComponent<ClipObject>();
        
        if (clipObject == null) return;
        clipObject.IsInside = false;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        
        Gizmos.color = new Color(0,1,0,0.2f);
        Gizmos.DrawCube(transform.position, boxCollider.size);
    }
#endif
    
}