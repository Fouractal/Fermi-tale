using Cinemachine;
using Managers.GameManage;
using UnityEngine;

namespace Game.FD
{
    public class FD_Scene : GameScene
    {
        protected override void Awake()
        {
            base.Awake();
            
            GameObject mainCharacterPrefab = Resources.Load<GameObject>("Prefabs/MainCharacter/MainCharacter_Prefab");
            GameObject playerObject = Instantiate(mainCharacterPrefab);
            PlayerCharacterManager.Instance.player = playerObject.GetComponent<Player>();
        
            CinemachineVirtualCamManager.Instance.virtualCamera = GameObject.Find("followCam").GetComponent<CinemachineVirtualCamera>();
            CinemachineVirtualCamManager.Instance.cinemachineOrbitalTransposer = CinemachineVirtualCamManager.Instance.virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
            CinemachineVirtualCamManager.Instance.virtualCamera.LookAt = playerObject.transform;
            CinemachineVirtualCamManager.Instance.virtualCamera.Follow = playerObject.transform;
        
            GameObject touchPadPrefab = UIManager.Instance.ShowSceneUI("Prefabs/UI/TouchPadCanvas");
        }
    }
}