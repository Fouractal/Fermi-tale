using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraTurnController : MonoBehaviour
{
    private TouchPad _touchPad;
    private bool _isTurning = false;

    private Canvas _canvas;
    private CanvasScaler _canvasScaler;

    private Vector3[] directions = { new Vector3(-8, 12, -8), new Vector3(8, 12, -8),
                                     new Vector3(8, 12, 8), new Vector3(-8, 12, 8)};

    private int index = 0;

    private void Start()
    {
        _touchPad = TouchPad.Instance;
        _touchPad.OnDoubleTap += CameraTurn;
    }

    private void CameraTurn(PointerEventData eventData)
    {
        if (_isTurning) return;
        _isTurning = true;
        
        if (eventData.position.x <= 540)
        {
            //orbitalTransposer.m_FollowTransform = target;
            CameraTurnLeft();
        }
        else
        {
            CameraTurnRight();
        }
    }
    
    private void CameraTurnLeft()
    {
        Debug.Log("TestLeft");
        var sequence = DOTween.Sequence();
        sequence
            .AppendCallback(() => index += 1);
    }

    private void CameraTurnRight()
    {
        Debug.Log("TestRight");
        
        var sequence = DOTween.Sequence();
        sequence
            .Append(Camera.main.transform.DOLocalRotate(Vector3.back, 2f, RotateMode.FastBeyond360).SetEase(Ease.InOutCubic))
            .AppendCallback(()=> _isTurning = false);
    }
}
