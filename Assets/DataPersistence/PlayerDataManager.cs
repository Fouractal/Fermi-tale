using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerDataManager : Singleton<PlayerDataManager>, IDataPersistence
{
    public Define.Scene sceneEnumType = Define.Scene.NONE;
    public int chapterIndex = 0;
    
    public bool isBGMOn;
    public bool isEffectSoundOn;

#if UNITY_EDITOR
    [SerializeField] private TextMeshProUGUI sceneNameText;
    [SerializeField] private TextMeshProUGUI chapText;
    [SerializeField] private TextMeshProUGUI isBgmOnText;
    [SerializeField] private TextMeshProUGUI isEffectSoundOnText;
#endif

    public void LoadData(PlayerData data)
    {
        this.sceneEnumType = data.sceneName;
        this.chapterIndex = data.chapterIndex;
        this.isBGMOn = data.isBGMOn;
        this.isEffectSoundOn = data.isEffectSoundOn;

#if UNITY_EDITOR
        sceneNameText.text = "Stage : " + sceneEnumType;
        chapText.text = "Chap : " + chapterIndex;
        isBgmOnText.text = "BGM : " + isBGMOn;
        isEffectSoundOnText.text = "SoundEffect : " + isEffectSoundOn;
#endif
    }

    public void SaveData(ref PlayerData data)
    {
        data.sceneName = GetCurrentSceneEnumType();
        data.chapterIndex = this.chapterIndex;
        data.isBGMOn = this.isBGMOn;
        data.isEffectSoundOn = this.isEffectSoundOn;
    }

    public void ResetData(ref PlayerData data)
    {
        Debug.Log("Reset Data!");
        this.sceneEnumType = Define.Scene.NONE;
        this.chapterIndex = 0;
        this.isBGMOn = true;
        this.isEffectSoundOn = true;
    }

    public void AddSceneIndex()
    {
        sceneEnumType++;
        chapterIndex = 0;
#if UNITY_EDITOR
        sceneNameText.text = "Stage : " + GetSceneName((int)sceneEnumType);
        chapText.text = "Chap : " + chapterIndex;
#endif
    }

    public Define.Scene GetCurrentSceneEnumType()
    {
        Define.Scene scene = Define.Scene.NONE;
        switch (SceneManager.GetActiveScene().name)
        {
            case "MainRoomScene":
                scene = Define.Scene.MainRoomScene;
                break;
            case "StreetScene":
                scene = Define.Scene.StreetScene;
                break;
            case "FriendScene":
                scene = Define.Scene.FriendScene;
                break;
            case "LoverScene":
                scene = Define.Scene.LoverScene;
                break;
            case "FamilyScene":
                scene = Define.Scene.FamilyScene;
                break;
            default:
                Debug.LogError("Scene Name mismatch!");
                scene = Define.Scene.NONE;
                break;
        }

        return scene;
    }
    public void AddNextSceneIndex()
    {
        Define.Scene scene = GetCurrentSceneEnumType();

        ++scene;
    }
    public void MinSceneIndex()
    {
        sceneEnumType--;
#if UNITY_EDITOR
        sceneNameText.text = "Stage : " + GetSceneName((int)sceneEnumType);
#endif
    }

    public void AddChapterIndex()
    {
        chapterIndex++;
#if UNITY_EDITOR
        chapText.text = "Chap : " + chapterIndex;
#endif
    }

    public void MinChapterIndex()
    {
        chapterIndex--;
#if UNITY_EDITOR
        chapText.text = "Chap : " + chapterIndex;
#endif
    }

    public void BGMOnOff()
    {
        isBGMOn = !isBGMOn;
#if UNITY_EDITOR
        isBgmOnText.text = "BGM : " + isBGMOn;
#endif
    }

    public void EffectSoundOnOff()
    {
        isEffectSoundOn = !isEffectSoundOn;
#if UNITY_EDITOR
        isEffectSoundOnText.text = "Effect Sound : " + isEffectSoundOn;
#endif
    }

    private string GetSceneName(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 0:
                return "MN";
            case 1:
                return "FM";
            case 2:
                return "ST";
            case 3:
                return "FD";
            case 4:
                return "LV";
            case 5:
                return "MR";
            default:
                return null;
        }
    }
}