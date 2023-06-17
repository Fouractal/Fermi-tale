using System;
using UnityEngine;

public class DistanceEventData
{
    public GameObject targetObject;
    public float limitDistance;
    public Action func;             // 각각의 오브젝트에서 설정하는게 더 좋아보인다.
}