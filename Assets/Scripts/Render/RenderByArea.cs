using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderByArea : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private SkinnedMeshRenderer _skinnedMeshRenderer;
    private Material[] _materials;
    private bool _isInside = false;
    public bool IsInside
    {
        get { return _isInside;}
        set
        {
            if (_isInside && value == false)
            {
                _isInside = false;
                SetRender(false);
            }
            else if (!_isInside && value == true)
            {
                _isInside = true;
                SetRender(true);
            }
            else
            {
                _isInside = value;
            }
        }
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        if(_meshRenderer) _materials = _meshRenderer.materials;
        if (_skinnedMeshRenderer) _materials = _skinnedMeshRenderer.materials;
        
        foreach (var material in _materials)
        {
            material.SetFloat("_IsStartGame", 1f);    
        }
    }

    private void Start()
    {
        SetPivotPoint();
    }
    void Update()
    {
        if (IsInside)
        {
            SetPivotPoint();
        }
    }

    private void SetPivotPoint()
    {
        Vector3 pivot = RenderArea.Instance.transform.position;
        
        foreach (var material in _materials)
        {
            material.SetVector("_PivotPoint", pivot);    
        }
    }

    private void SetRender(bool active)
    {
        if(_meshRenderer) _meshRenderer.enabled = active;
        if (_skinnedMeshRenderer) _skinnedMeshRenderer.enabled = active;
    }
}
