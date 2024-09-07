using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : Singleton<CameraManager>
{
    public FermiCamera fermiCamera;

    
    #region prev code
    public Transform cameraRoot;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineFreeLook cinemachineFreeLook;
    public CameraTurnController cameraTurnController;
    public CinemachineOrbitalTransposer cinemachineOrbitalTransposer;
    /*protected override void Awake()
    {
        base.Awake();
    }*/
    #endregion

}
