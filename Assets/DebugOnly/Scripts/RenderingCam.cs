using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RenderingCam : MonoBehaviour
{
    // 플레이어 영역 내 들어온 오브젝트의 방향만 검사해서 소환

    private Transform _transform;
    private Collider _colliderChecker;
    [SerializeField] private float moveSpeed = 5f;
    public List<RenderingByDirection> triggeredGameobject;

    [SerializeField]
    private CameraDirection cameraDirection;
    void Start()
    {
        triggeredGameobject = new List<RenderingByDirection>();
        _transform = GetComponent<Transform>();
        _colliderChecker = GetComponentInChildren<Collider>();

    }

    private void Init()
    {
        cameraDirection = CameraDirection.NE;
        Debug.Log("초기 방향 북동쪽으로 설정");
    }
    void Update()
    {
        Move();
        
        // 아래 입력은 카메라에서 접근한 입력. 임의로 키보드 입력으로 처리
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < triggeredGameobject.Count; i++)
            {
                triggeredGameobject[i].LookNorthEast();
            }

            cameraDirection = CameraDirection.NE;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            for (int i = 0; i < triggeredGameobject.Count; i++)
            {
                triggeredGameobject[i].LookSouthEast();
            }

            cameraDirection = CameraDirection.SE;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < triggeredGameobject.Count; i++)
            {
                triggeredGameobject[i].LookSouthWest();
            }

            cameraDirection = CameraDirection.SW;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < triggeredGameobject.Count; i++)
            {
                triggeredGameobject[i].LookNorthWest();
            }

            cameraDirection = CameraDirection.NW;
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }
    private void OnDrawGizmos()
    {
        // 기즈모 색상 설정 (예: 빨간색)
        Gizmos.color = Color.red;

        // 플레이어의 현재 위치를 기준으로 기즈모를 그립니다.
        Vector3 playerPosition = transform.position;

        // 박스의 중심 위치 계산
        Vector3 boxCenter = playerPosition;

        // 박스의 크기 (10x10x10)
        Vector3 boxSize = new Vector3(10f, 10f, 10f);

        // 박스 기즈모 그리기
        Gizmos.DrawWireCube(boxCenter, boxSize);
    }
}
public enum CameraDirection
{
    NE,
    SE,
    SW,
    NW
}