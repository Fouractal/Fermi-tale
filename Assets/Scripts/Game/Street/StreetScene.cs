using Cinemachine;
using Managers.GameManage;
using UnityEngine;

namespace Game.StartRoom
{
    public class StreetScene : GameScene
    {
        protected override void Awake()
        {
            base.Awake();
            
            // //MN Room 생성
            // GameObject MNPrefab = Resources.Load<GameObject>("Prefabs/MN/MN_Prefab");
            // Instantiate(MNPrefab);
        
            //캐릭터 생성
            GameObject mainCharacterPrefab = Resources.Load<GameObject>("Prefabs/MainCharacter/MainCharacter_Prefab");
            GameObject playerObject = Instantiate(mainCharacterPrefab, GameObject.Find("ObjectRoot").transform);
            PlayerManager.Instance.player = playerObject.GetComponent<Player>();
        
            // Cinemachine Virtual Cam에 Player 할당, 근데 씬 생성될 때 동적으로 virtualCam 컴포넌트 싱글톤으로 생성됨 근데 다시 할당한다?
            //cameraRoot.transform.SetParent();
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
