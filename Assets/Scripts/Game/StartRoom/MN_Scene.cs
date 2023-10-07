using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class MN_Scene : MonoBehaviour
{
    private void Awake()
    {
        // //MN Room 생성
        // GameObject MNPrefab = Resources.Load<GameObject>("Prefabs/MN/MN_Prefab");
        // Instantiate(MNPrefab);
        
        //캐릭터 생성
        GameObject mainCharacterPrefab = Resources.Load<GameObject>("Prefabs/MainCharacter/MainCharacter_Prefab");
        GameObject playerObject = Instantiate(mainCharacterPrefab, GameObject.Find("ObjectRoot").transform);
        PlayerCharacterManager.Instance.player = playerObject.GetComponent<Player>();
        
        // Cinemachine Virtual Cam에 Player 할당, 근데 씬 생성될 때 동적으로 virtualCam 컴포넌트 싱글톤으로 생성됨 근데 다시 할당한다?
        //cameraRoot.transform.SetParent();
        CinemachineVirtualCamManager.Instance.virtualCamera = GameObject.Find("followCam").GetComponent<CinemachineVirtualCamera>();
        CinemachineVirtualCamManager.Instance.virtualCamera.LookAt = playerObject.transform;
        CinemachineVirtualCamManager.Instance.virtualCamera.Follow = playerObject.transform;
        
        GameObject touchPadPrefab = UIManager.Instance.ShowSceneUI("Prefabs/UI/TouchPadCanvas");
    }
}
