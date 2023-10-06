using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RenderingByDirection : MonoBehaviour
{
    // 플레이어 범위 내에 감지된 영역만 보이게 함.
    // 카메라 -> 각 오브젝트(방향 포함)
    // 동서남북 방향 기준
    // 북동, 남동, 남서, 북서 방향의 오브제트 내려옴. (페이드 인도 넣을까?)
    // 현재 보이는 방향 고려해서 오브젝트 올리고 내리도록 해야 됨. 예를 들어 북동을 보고 있다가 남동으로 카메라 전환을 할 경우 동은 유지, 북은 올리고 남은 내려옴.
    [SerializeField] private CardinalPoint cardinalPoint;
    [SerializeField] private Material _material;
    public bool isTriggered = false;
    private void Start()
    {
        Init();
        _material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        
    }
    
    private void Init()
    {
        Debug.Log("initial direction setting");
    }
    
    public void ObjectMovingUp()
    {
        Debug.Log( gameObject.name+ " is Moving Up and Fade Out");
        transform.DOMoveY(5f, 0.5f);
        _material.DOFade(0f, 0.5f);
    }

    public void ObjectMovingDown()
    {
        Debug.Log( gameObject.name+ " is Moving Down and Fade In");
        transform.DOMoveY(0f, 0.5f);
        _material.DOFade(1f, 0.5f);
    }

    public void LookNorthEast()
    {
        Debug.Log("NE(북동)");
        if (cardinalPoint == CardinalPoint.North || cardinalPoint == CardinalPoint.East)
        {
            ObjectMovingDown();
        }else ObjectMovingUp();
    }

    public void LookSouthEast()
    {
        Debug.Log("SE(남동)");
        if (cardinalPoint == CardinalPoint.South || cardinalPoint == CardinalPoint.East)
        {
            ObjectMovingDown();
        }else ObjectMovingUp();
    }

    public void LookSouthWest()
    {
        Debug.Log("SW(남서)");
        if (cardinalPoint == CardinalPoint.South || cardinalPoint == CardinalPoint.West)
        {
            ObjectMovingDown();
        }else ObjectMovingUp();
    }

    public void LookNorthWest()
    {
        Debug.Log("NW(북서)");
        if (cardinalPoint == CardinalPoint.North || cardinalPoint == CardinalPoint.West)
        {
            ObjectMovingDown();
        }else ObjectMovingUp();
    }
}

public enum CardinalPoint
{
    North,
    South,
    East,
    West
}


