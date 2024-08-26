using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Managers.GameManage;
using UnityEngine;

namespace Game.FM
{
    public class FM_Scene : GameScene
    {
        private void Awake()
        {
            // TODO : 씬 초기화 코드

            GameObject mainCharacterPrefab = Resources.Load<GameObject>("Prefabs/MainCharacter/MainCharacter_Prefab");
            GameObject playerObject = Instantiate(mainCharacterPrefab, Vector3.up * 5, Quaternion.identity);
            // playerObject.transform.SetParent(GameObject.Find("ObjectRoot").transform);
            PlayerManager.Instance.player = playerObject.GetComponent<Player>();
        
            CameraManager.Instance.virtualCamera = GameObject.Find("followCam").GetComponent<CinemachineVirtualCamera>();
            CameraManager.Instance.cinemachineOrbitalTransposer = CameraManager.Instance.virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
            CameraManager.Instance.virtualCamera.LookAt = playerObject.transform;
            CameraManager.Instance.virtualCamera.Follow = playerObject.transform;
        
            GameObject touchPadPrefab = UIManager.Instance.ShowSceneUI("Prefabs/UI/TouchPadCanvas");
            GameManager.Instance.GameScene = this;
        }
    }
}

