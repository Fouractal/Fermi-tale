using UnityEngine;

public class RenderArea : Singleton<RenderArea>
{
    private void OnTriggerEnter(Collider other)
    {
        RenderByArea renderByArea = other.transform.GetComponent<RenderByArea>();
        RenderByDirection renderByDirection = other.transform.GetComponent<RenderByDirection>();
        
        if (renderByArea != null) renderByArea.IsInside = true;
        if (renderByDirection != null) renderByDirection.isInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        RenderByArea renderByArea = other.transform.GetComponent<RenderByArea>();
        RenderByDirection renderByDirection = other.transform.GetComponent<RenderByDirection>();
        
        if (renderByArea != null) renderByArea.IsInside = false;
        if (renderByDirection != null) renderByDirection.isInside = false;
    }

    private void Update()
    {
        // Quternion -> Euler로 바꿔서 * (-1) -> Quternion
        transform.localRotation = 
            Quaternion.Euler(0, -PlayerManager.Instance.player.transform.rotation.eulerAngles.y, 0);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        
        Gizmos.color = new Color(0,1,0,0.2f);
        Gizmos.DrawCube(transform.position, boxCollider.size);
    }
#endif
    
}
