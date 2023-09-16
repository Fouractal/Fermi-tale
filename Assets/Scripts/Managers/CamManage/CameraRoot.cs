using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoot : MonoBehaviour
{
    private void Awake()
    {
        CinemachineVirtualCamManager.Instance.cameraRoot = gameObject;
    }
}
