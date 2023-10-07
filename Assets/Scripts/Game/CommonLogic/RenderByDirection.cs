using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RenderByDirection : MonoBehaviour
{
    private float _maxZAxis = 0f;
    private float _minZAxis  = 0f;
    private float _maxXAxis  = 0f;
    private float _minXAxis  = 0f;
    
    private BoxCollider _collider;
    
    public bool isNorthSide = false;
    public bool isSouthSide = false;
    public bool isEastSide = false;
    public bool isWestSide = false;
    
    private MeshRenderer _meshRenderer;
    private Material[] _materials;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _maxZAxis = _collider.bounds.max.z;
        _minZAxis = _collider.bounds.min.z;
        _maxXAxis = _collider.bounds.max.x;
        _minXAxis = _collider.bounds.min.x;

        _meshRenderer = GetComponent<MeshRenderer>();
        _materials = _meshRenderer.materials;
    }

    public void Update()
    {
        if (CinemachineVirtualCamManager.Instance.cameraTurnController == null) return;
        UpdateState(PlayerCharacterManager.Instance.player.transform.position);
        RenderByCameraDirection(CinemachineVirtualCamManager.Instance.cameraTurnController.cameraDirection);
    }

    private void UpdateState(Vector3 playerPos)
    {
        isNorthSide = false;
        isSouthSide = false;
        isEastSide = false;
        isWestSide = false;

        if (playerPos.z < _minZAxis) isNorthSide = true;
        if (playerPos.z > _maxZAxis) isSouthSide = true;
        if (playerPos.x < _minXAxis) isEastSide = true;
        if (playerPos.x > _maxXAxis) isWestSide = true;
    }

    private void RenderByCameraDirection(Define.CameraDirection direction)
    {
        switch (direction)
        {
            case Define.CameraDirection.NE:
                _meshRenderer.enabled = isNorthSide || isEastSide;
                break;
            case Define.CameraDirection.SE:
                _meshRenderer.enabled = isSouthSide || isEastSide;
                break;
            case Define.CameraDirection.SW:
                _meshRenderer.enabled = isSouthSide || isWestSide;
                break;
            case Define.CameraDirection.NW:
                _meshRenderer.enabled = isNorthSide || isWestSide;
                break;
        }
    }
}

