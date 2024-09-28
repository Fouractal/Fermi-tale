using Cinemachine;
using Managers.GameManage;
using UnityEngine;

namespace Game.FD
{
    public class FriendScene : GameScene
    {
        protected override void Awake()
        {
            base.Awake();

            GameObject mainCharacterPrefab = Resources.Load<GameObject>("Prefabs/MainCharacter/MainCharacter_Prefab");
            GameObject playerObject = Instantiate(mainCharacterPrefab);
            PlayerManager.Instance.player = playerObject.GetComponent<Player>();

            GameObject virtualCam = GameObject.Find("followCam");
            CameraManager.Instance.fermiCamera = virtualCam.GetComponent<FermiCamera>();
            CameraManager.Instance.virtualCamera = virtualCam.GetComponent<CinemachineVirtualCamera>();
            CameraManager.Instance.cinemachineOrbitalTransposer = CameraManager.Instance.virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
            CameraManager.Instance.virtualCamera.LookAt = playerObject.transform;
            CameraManager.Instance.virtualCamera.Follow = playerObject.transform;

            GameObject touchPadPrefab = UIManager.Instance.ShowSceneUI("Prefabs/UI/TouchPadCanvas");
        }
    }
}