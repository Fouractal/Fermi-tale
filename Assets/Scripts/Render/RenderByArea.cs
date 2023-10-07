using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderByArea : MonoBehaviour
{
    private Material[] _materials;
    private bool _isInside = false;
    public bool IsInside
    {
        get { return _isInside;}
        set
        {
            if (_isInside && value == false)
            {
                IEnumerator ChangeStatusAfterOneSecond()
                {
                    yield return new WaitForSecondsRealtime(0.1f);
                    _isInside = false;

                    SetPivotPoint();
                }

                StartCoroutine(ChangeStatusAfterOneSecond());
            }
            else
            {
                _isInside = value;
            }
        }
    }

    private void Awake()
    {
        _materials = GetComponent<MeshRenderer>().materials;
        
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
}
