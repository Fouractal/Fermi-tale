using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerDataManager : Singleton<PlayerDataManager>, IDataPersistence
{
    public Define.Scene sceneEnumType;
    public int chapterIndex = 0;

    // public List<ItemData> itemDatas; ItemData 사용 x
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
        /*foreach (KeyValuePair<string,bool> pair in data.sphereCollected)
        {
            if (pair.Value)
            {
                _collectedSphereIndex++;
            }
        }
        _collectedSphereText.text = "Collected Sphere : " + _collectedSphereIndex.ToString();    
        */
    }

    public void SaveData(ref PlayerData data)
    {
        data.sceneName = this.sceneEnumType;
        data.chapterIndex = this.chapterIndex;
        data.isBGMOn = this.isBGMOn;
        data.isEffectSoundOn = this.isEffectSoundOn;

        // data.collectedIndex = this.collectedSphereIndex;
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