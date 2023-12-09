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

    [SerializeField] private CinemachineOrbitalTransposer orbitalTransposer;
    
    public Define.CameraDirection cameraDirection = Define.CameraDirection.NE;
    public delegate void DirectionHandler(Define.CameraDirection nextDirection);
    public event DirectionHandler OnChangeDirection;

    private void Start()
    {
        _touchPad = TouchPad.Instance;
        _touchPad.doubleTap.OnDoubleTap += CameraTurn;

        orbitalTransposer = CinemachineVirtualCamManager.Instance.cinemachineOrbitalTransposer;
        orbitalTransposer.m_RecenterToTargetHeading.m_enabled = true;
        orbitalTransposer.m_Heading.m_Definition = CinemachineOrbitalTransposer.Heading.HeadingDefinition.WorldForward;
        orbitalTransposer.m_Heading.m_Bias = 45;
        orbitalTransposer.m_XAxis.Value = 0;
    }

    private void CameraTurn(PointerEventData eventData)
    {
        if (_isTurning) return;
        _isTurning = true;
        
        if (eventData.position.x <= 540)
        {
            CameraTurnCounterClockwise();
        }
        else
        {
            CameraTurnClockwise();
        }

        _isTurning = false;
    }
    
    private void CameraTurnClockwise()
    {
        orbitalTransposer.m_Heading.m_Bias += 90;
        orbitalTransposer.m_XAxis.Value -= 90;

        cameraDirection = (Define.CameraDirection)(((int)cameraDirection + 1) % 4);
        OnChangeDirection?.Invoke(cameraDirection);
        
    }

    private void CameraTurnCounterClockwise()
    {
        orbitalTransposer.m_Heading.m_Bias -= 90;
        orbitalTransposer.m_XAxis.Value += 90;
        
        cameraDirection = (Define.CameraDirection)(((int)cameraDirection + 3) % 4);
        OnChangeDirection?.Invoke(cameraDirection);
        
    }
}
