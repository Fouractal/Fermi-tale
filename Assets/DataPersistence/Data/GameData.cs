using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int stageIndex;
    public int chapterIndex;
    public int collectedIndex;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> sphereCollected;
    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        this.stageIndex = 0;
        this.chapterIndex = 0;
        playerPosition = Vector3.zero;
        sphereCollected = new SerializableDictionary<string, bool>();
    }
}
