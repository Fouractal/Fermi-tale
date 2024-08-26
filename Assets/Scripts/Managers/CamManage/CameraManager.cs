using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : Singleton<CameraManager>
{
    public Transform cameraRoot;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineFreeLook cinemachineFreeLook;
    public CameraTurnController cameraTurnController;
    public CinemachineOrbitalTransposer cinemachineOrbitalTransposer;

    private void Awake()
    {
        cameraTurnController = GetComponent<CameraTurnController>();
    }
}
