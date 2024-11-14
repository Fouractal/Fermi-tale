using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RenderByDirection : MonoBehaviour
{
    private Vector3 _objectMaxPos;
    private Vector3 _objectMinPos;
    
    [SerializeField]
    private Collider _collider;
    
    public bool isNorthSide = false;
    public bool isSouthSide = false;
    public bool isEastSide = false;
    public bool isWestSide = false;
    
    public bool isInside = false;

    private MeshRenderer _meshRenderer;
    private Material[] _materials;

    private Transform _playerTransform;
    private FermiCamera _fermiCamera;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _objectMaxPos = _collider.bounds.max;
        _objectMinPos = _collider.bounds.min;

        _meshRenderer = GetComponent<MeshRenderer>();
        _materials = _meshRenderer.materials;
    }

    private void Start()
    {
        _playerTransform = PlayerManager.Instance.player.transform;
        _fermiCamera = CameraManager.Instance.fermiCamera;
    }

    public void Update()
    {
        if (_playerTransform == null || _fermiCamera == null) return;
        UpdateDirectionFromPlayer(_playerTransform.position);
        RenderByCameraDirection(_fermiCamera.cameraDirection);
    }

    private void UpdateDirectionFromPlayer(Vector3 playerPos)
    {
        isNorthSide = Vector3.Dot(_objectMinPos-playerPos, Vector3.forward) > 0;
        isSouthSide = Vector3.Dot(_objectMaxPos-playerPos, Vector3.forward) < 0;
        isEastSide = Vector3.Cross(_objectMinPos-playerPos, Vector3.forward).y < 0;
        isWestSide = Vector3.Cross(_objectMaxPos-playerPos, Vector3.forward).y > 0;
    }

    private void RenderByCameraDirection(Define.CameraDirection direction)
    {
        switch (direction)
        {
            case Define.CameraDirection.NE:
                _meshRenderer.enabled = !isSouthSide && !isWestSide;
                break;
            case Define.CameraDirection.SE:
                _meshRenderer.enabled = !isNorthSide && !isWestSide;
                break;
            case Define.CameraDirection.SW:
                _meshRenderer.enabled = !isNorthSide && !isEastSide;
                break;
            case Define.CameraDirection.NW:
                _meshRenderer.enabled = !isSouthSide && !isEastSide;
                break;
        }
    }
}

