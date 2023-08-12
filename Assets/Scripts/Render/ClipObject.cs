using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipObject : MonoBehaviour
{
    private Material material;
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

    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;
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
        Vector3 pivot = ClippingChecker.Instance.transform.position;
        material.SetVector("_PivotPoint", pivot);
    }
}
