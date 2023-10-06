using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class RenderByDirection : MonoBehaviour
{
    public static Define.RenderDirection[] renderTargets = {Define.RenderDirection.N , Define.RenderDirection.E};
    private Material[] _materials;
    private MeshRenderer _meshRenderer;

    [SerializeField]
    private Define.RenderDirection renderDirection;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _materials = GetComponent<MeshRenderer>().materials;
        
        SetRenderByCameraDirection(Define.CameraDirection.NE);
        
        //CinemachineVirtualCamManager.Instance.cameraTurnController.OnChangeDirection += SetRenderByCameraDirection;
    }

    private void SetRenderByCameraDirection(Define.CameraDirection renderTargetDirection)
    {
        switch (renderTargetDirection)
        {
            case Define.CameraDirection.NE:
                renderTargets[0] = Define.RenderDirection.N;
                renderTargets[1] = Define.RenderDirection.E;
                break;
            case Define.CameraDirection.SE:
                renderTargets[0] = Define.RenderDirection.S;
                renderTargets[1] = Define.RenderDirection.E;
                break;
            case Define.CameraDirection.SW:
                renderTargets[0] = Define.RenderDirection.S;
                renderTargets[1] = Define.RenderDirection.W;
                break;
            case Define.CameraDirection.NW:
                renderTargets[0] = Define.RenderDirection.N;
                renderTargets[1] = Define.RenderDirection.W;
                break;
        }

        Debug.Log($"Direction : {renderTargetDirection}");
        
        if (renderTargets.Contains(renderDirection))
        {
            Debug.Log("Contain");

            _meshRenderer.enabled = true;
            _materials[0].DOFade(1, 1f);
            // foreach (var material in _materials)
            // {
            //     material.SetFloat("_IsRenderDirection", 1);    
            // }
        }
        else
        {
            Debug.Log("NotContain");
            _meshRenderer.enabled = false;
            // foreach (var material in _materials)
            // {
            //     material.SetFloat("_IsRenderDirection", 0);    
            // }
        }
    }
}
