using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FermiCamera : MonoBehaviour
{
    public TouchPad touchPad;
    public bool isTurning = false;

    [SerializeField] private CinemachineOrbitalTransposer orbitalTransposer;

    public Define.CameraDirection cameraDirection = Define.CameraDirection.NE;
    
    public delegate void DirectionHandler(Define.CameraDirection nextDirection);
    public event DirectionHandler OnChangeDirection;

    // Start is called before the first frame update
    void Start()
    {
        touchPad = TouchPad.Instance;
        // touchPad.doubleTap.OnDoubleTap += CameraTurn;

        orbitalTransposer = CameraManager.Instance.cinemachineOrbitalTransposer;
        orbitalTransposer.m_RecenterToTargetHeading.m_enabled = true;
        orbitalTransposer.m_Heading.m_Definition = CinemachineOrbitalTransposer.Heading.HeadingDefinition.WorldForward;
        orbitalTransposer.m_Heading.m_Bias = 45;
        orbitalTransposer.m_XAxis.Value = 0;
    }
    
    
    public void CameraTurnClockwise()
    {
        orbitalTransposer.m_Heading.m_Bias += 90;
        orbitalTransposer.m_XAxis.Value -= 90;

        cameraDirection = (Define.CameraDirection)(((int)cameraDirection + 1) % 4);
        OnChangeDirection?.Invoke(cameraDirection);
        
    }

    public void CameraTurnCounterClockwise()
    {
        orbitalTransposer.m_Heading.m_Bias -= 90;
        orbitalTransposer.m_XAxis.Value += 90;
        
        cameraDirection = (Define.CameraDirection)(((int)cameraDirection + 3) % 4);
        OnChangeDirection?.Invoke(cameraDirection);
        
    }
}
