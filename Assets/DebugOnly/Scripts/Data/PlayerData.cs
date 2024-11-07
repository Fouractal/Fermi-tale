using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class PlayerData
{
    public Define.Scene sceneName;
    public int chapterIndex;

    public List<ItemData> itemDataList;

    // 사용자 설정
    public bool isBGMOn;
    public bool isEffectSoundOn;

    public PlayerData()
    {
        this.sceneName = Define.Scene.MainRoomScene;
        this.chapterIndex = 0;

        itemDataList = new List<ItemData>();

        this.isBGMOn = true;
        this.isEffectSoundOn = true;
    }
}

[System.Serializable]
public class ItemData
{
    public string itemId;
    public bool isAcquired;
    public bool isUsed;
}