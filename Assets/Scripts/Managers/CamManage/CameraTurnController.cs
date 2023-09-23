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

    private Define.CameraDirection _cameraDirection = Define.CameraDirection.NE;

    public delegate void DirectionHandler(Define.CameraDirection nextDirection);
    public event DirectionHandler OnChangeDirection;
    
    private void Start()
    {
        _touchPad = TouchPad.Instance;
        _touchPad.OnDoubleTap += CameraTurn;
        
        OnChangeDirection?.Invoke(_cameraDirection);
    }

    private void CameraTurn(PointerEventData eventData)
    {
        if (_isTurning) return;
        _isTurning = true;
        
        if (eventData.position.x <= 540)
        {
            CameraTurnLeft();
        }
        else
        {
            CameraTurnRight();
        }
    }
    
    private void CameraTurnLeft()
    {
        Debug.Log("TurnLeft");
        _cameraDirection = (Define.CameraDirection)(((int)_cameraDirection -1 + 4) % 4);
        OnChangeDirection?.Invoke(_cameraDirection);
        _isTurning = false;
    }

    private void CameraTurnRight()
    {
        Debug.Log("TurnRight");
        _cameraDirection = (Define.CameraDirection)(((int)_cameraDirection + 1) % 4);
        OnChangeDirection?.Invoke(_cameraDirection);
        _isTurning = false;
    }
}
