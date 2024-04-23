using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(PlayerData data);
    void SaveData(ref PlayerData data);
    void ResetData(ref PlayerData data);
}
