using System;
using UnityEngine;
using Object = System.Object;

[Serializable]
public class AreaEventData
{
    public EventArea eventArea;
    public Define.AreaType areaType;
    public Vector3 areaPos;
    public float areaSize;

    public Action func;             // 각각의 오브젝트에서 설정하는게 더 좋아보인다.
    public int maxExecuteCount;
    public int curExecuteCount;
    
    // maxExecuteCount = -1 to infinite
    public AreaEventData(Vector3 areaPos, float areaSize, Action func, int maxExecuteCount = 1, Define.AreaType areaType = Define.AreaType.Cube)
    {
        this.eventArea = null;
        this.areaType = areaType;
        this.areaPos = areaPos;
        this.areaSize = areaSize;
        this.maxExecuteCount = maxExecuteCount;
        this.curExecuteCount = 0;
            
        this.func = func;
    }
}