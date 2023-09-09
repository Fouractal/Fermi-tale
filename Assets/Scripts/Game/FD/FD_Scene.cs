using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FD_Scene : MonoBehaviour
{
    private void Awake()
    {
        //캐릭터 생성
        GameObject mainCharacterPrefab = Resources.Load<GameObject>("Prefabs/MainCharacter/MainCharacter_Prefab");
        GameObject playerObject = Instantiate(mainCharacterPrefab);
        PlayerCharacterManager.Instance.playerController = playerObject.GetComponent<PlayerController>();
        
        CinemachineVirtualCamManager.Instance.virtualCamera = GameObject.Find("followCam").GetComponent<CinemachineVirtualCamera>();
        CinemachineVirtualCamManager.Instance.virtualCamera.LookAt = playerObject.transform;
        CinemachineVirtualCamManager.Instance.virtualCamera.Follow = playerObject.transform;
        
        //조이스틱 생성
        GameObject joystickUICanvasPrefab = UIManager.Instance.ShowSceneUI("Prefabs/UI/JoystickUICanvas");
        //Instantiate(joystickUICanvasPrefab);    
    }
}