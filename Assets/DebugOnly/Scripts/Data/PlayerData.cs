using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class PlayerData
{
    public string sceneName;
    public int chapterIndex;

    [FormerlySerializedAs("itemDatas")] public List<ItemData> itemDataList;
    
    // 사용자 설정
    public bool isBGMOn;
    public bool isSoundEffectOn;

    public PlayerData()
    {
        this.sceneName = "";
        this.chapterIndex = 0;
        
        itemDataList = new List<ItemData>();

        this.isBGMOn = true;
        this.isSoundEffectOn = true;
    }
}

[System.Serializable]
public class ItemData
{
    public string itemId;
    public bool isAcquired;
    public bool isUsed;
}