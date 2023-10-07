using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;


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
        _touchPad.OnDoubleTap += CameraTurn;

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
            CameraTurnClockwise();
        }
        else
        {
            CameraTurnCounterClockwise();
        }

        _isTurning = false;
    }
    
    private void CameraTurnClockwise()
    {
        orbitalTransposer.m_Heading.m_Bias += 90;
        orbitalTransposer.m_XAxis.Value -= 90;
    }

    private void CameraTurnCounterClockwise()
    {
        orbitalTransposer.m_Heading.m_Bias -= 90;
        orbitalTransposer.m_XAxis.Value += 90;
    }
}
