using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CinemachineVirtualCamManager : Singleton<CinemachineVirtualCamManager>
{
    public GameObject cameraRoot;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineFreeLook cinemachineFreeLook;
    public CameraTurnController cameraTurnController;
    public CinemachineOrbitalTransposer cinemachineOrbitalTransposer;

    private void Awake()
    {
        cinemachineOrbitalTransposer = virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }
}
