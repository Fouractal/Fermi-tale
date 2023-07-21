using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MN_Scene : MonoBehaviour
{
    private void Awake()
    {
        //MN Room 생성
        GameObject MNPrefab = Resources.Load<GameObject>("Prefabs/MN/MN_Prefab");
        Instantiate(MNPrefab);
        
        //캐릭터 생성
        GameObject mainCharacterPrefab = Resources.Load<GameObject>("Prefabs/MainCharacter/MainCharacter_Prefab");
        PlayerCharacterManager.Instance.playerController = Instantiate(mainCharacterPrefab).GetComponent<PlayerController>();
        
        //조이스틱 생성
        GameObject joystickUICanvasPrefab = Resources.Load<GameObject>("Prefabs/UI/JoystickUICanvas");
        Instantiate(joystickUICanvasPrefab);
    }
}
