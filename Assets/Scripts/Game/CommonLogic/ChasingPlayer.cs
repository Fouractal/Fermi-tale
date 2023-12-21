using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[ExecuteInEditMode] // 편집 모드에서 테스트하기 위해 편집 모드에서 실행 추가
public class ChasingPlayer : MonoBehaviour
{
    [Header("Animation property")]
    [SerializeField] private Animator chasingAnimator;
    public Transform animationOriginTransform;
    public bool isChasing = false;
    [SerializeField] private Vector3 _lastPosition;
    [SerializeField] private Quaternion _lastRotation;
    
    
    private DOTweenPath _doTweenPath;
    void Start()
    {
        _doTweenPath = GetComponent<DOTweenPath>();
        
        _lastPosition = animationOriginTransform.position;
        _lastRotation = animationOriginTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            chasingAnimator.SetBool("IsChasing", true);    
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            chasingAnimator.SetBool("IsChasing", false);    
        }
    }

    
    // 애니메이션 이벤트, 애니메이션 종료 시점에 호출될 메서드
    public void OnAnimationEnd()
    {
        Debug.Log("Animation end! ");
        SaveAnimationEndTransform();
    }
    // 애니메이션 이벤트, 애니메이션 시작 시점에 호출될 메서드
    public void OnAnimationStart()
    {
        Debug.Log("Animation start! ");
        ResetPositionToLast();
    }
    
    
    // 애니메이션 종료 시점에 위치, 회전값을 기억

    public void SaveAnimationEndTransform()
    {
        _lastPosition = animationOriginTransform.position;
        _lastRotation = animationOriginTransform.rotation;
    }
    // 애니메이션 시작 시점에 호출될 메서드
    public void ResetPositionToLast()
    {
        transform.position = new Vector3(_lastPosition.x, 0.5f, _lastPosition.z);
        transform.rotation = _lastRotation;
        
    }
    public void ChasePlayer(GameObject playerObj)
    {
        Debug.Log("Chase!");
        // _doTweenPath.DOPause();
        transform.DOLookAt(playerObj.transform.position, 5f);
        // transform.DOMove(playerObj.transform.position, 5f);
    }
}