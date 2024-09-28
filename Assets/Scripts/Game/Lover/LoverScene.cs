using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Managers.GameManage;
using UnityEngine.Serialization;

namespace Game.LV
{
    public class LoverScene : GameScene
    {
        [SerializeField]
        private VignetteSystem vignetteSystem;
        
        protected override void Awake()
        {
            base.Awake();
            
            GameObject mainCharacterPrefab = Resources.Load<GameObject>("Prefabs/MainCharacter/MainCharacter_Prefab");
            GameObject playerObject = Instantiate(mainCharacterPrefab, Vector3.up * 5, Quaternion.identity);
            playerObject.transform.SetParent(GameObject.Find("ObjectRoot").transform);
            PlayerManager.Instance.player = playerObject.GetComponent<Player>();

            GameObject virtualCam = GameObject.Find("followCam");
            CameraManager.Instance.fermiCamera = virtualCam.GetComponent<FermiCamera>();
            CameraManager.Instance.virtualCamera = virtualCam.GetComponent<CinemachineVirtualCamera>();
            CameraManager.Instance.cinemachineOrbitalTransposer = CameraManager.Instance.virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
            CameraManager.Instance.virtualCamera.LookAt = playerObject.transform;
            CameraManager.Instance.virtualCamera.Follow = playerObject.transform;

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