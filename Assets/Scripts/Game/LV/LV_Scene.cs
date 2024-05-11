using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Managers.GameManage;
using UnityEngine.Serialization;

namespace Game.LV
{
    public class LV_Scene : GameScene
    {
        [FormerlySerializedAs("_darknessSystem")] [SerializeField]
        private VignetteSystem vignetteSystem;
        
        private void Awake()
        {
            GameObject mainCharacterPrefab = Resources.Load<GameObject>("Prefabs/MainCharacter/MainCharacter_Prefab");
            GameObject playerObject = Instantiate(mainCharacterPrefab, Vector3.up * 5, Quaternion.identity);
            playerObject.transform.SetParent(GameObject.Find("ObjectRoot").transform);
            PlayerCharacterManager.Instance.player = playerObject.GetComponent<Player>();
        
            CinemachineVirtualCamManager.Instance.virtualCamera = GameObject.Find("followCam").GetComponent<CinemachineVirtualCamera>();
            CinemachineVirtualCamManager.Instance.cinemachineOrbitalTransposer = CinemachineVirtualCamManager.Instance.virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
            CinemachineVirtualCamManager.Instance.virtualCamera.LookAt = playerObject.transform;
            CinemachineVirtualCamManager.Instance.virtualCamera.Follow = playerObject.transform;
        
            GameObject touchPadPrefab = UIManager.Instance.ShowSceneUI("Prefabs/UI/TouchPadCanvas");
            GameManager.Instance.GameScene = this;
        }

        public void SetScreenDarker()
        {
            vignetteSystem.SetScreenDarker();
        }

        public void SetScreenBrighter()
        {
            vignetteSystem.SetScreenBrighter();
        }
    }
    
}