using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FD_Scene : MonoBehaviour
{
    private void Awake()
    {
        GameObject mainCharacterPrefab = Resources.Load<GameObject>("Prefabs/MainCharacter/MainCharacter_Prefab");
        GameObject playerObject = Instantiate(mainCharacterPrefab);
        PlayerCharacterManager.Instance.player = playerObject.GetComponent<Player>();
        
        CinemachineVirtualCamManager.Instance.virtualCamera = GameObject.Find("followCam").GetComponent<CinemachineVirtualCamera>();
        CinemachineVirtualCamManager.Instance.virtualCamera.LookAt = playerObject.transform;
        CinemachineVirtualCamManager.Instance.virtualCamera.Follow = playerObject.transform;
        
        GameObject touchPadPrefab = UIManager.Instance.ShowSceneUI("Prefabs/UI/TouchPadCanvas"); 
        
        PlayerCharacterManager.Instance.playerController.InitEvent();
    }
}