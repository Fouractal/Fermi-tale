using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RenderArea : Singleton<RenderArea>
{
    private void OnTriggerEnter(Collider other)
    {
        RenderByArea renderByArea = other.transform.GetComponent<RenderByArea>();
        
        if (renderByArea == null) return;
        renderByArea.IsInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        RenderByArea renderByArea = other.transform.GetComponent<RenderByArea>();
        
        if (renderByArea == null) return;
        renderByArea.IsInside = false;
    }

    private void Update()
    {
        
        // Quternion -> Euler로 바꿔서 * (-1) -> Quternion
        transform.localRotation = 
            Quaternion.Euler(0, -PlayerCharacterManager.Instance.playerController.transform.rotation.eulerAngles.y, 0);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        
        Gizmos.color = new Color(0,1,0,0.2f);
        //Gizmos.DrawCube(transform.position, boxCollider.size);
    }
#endif
    
}
