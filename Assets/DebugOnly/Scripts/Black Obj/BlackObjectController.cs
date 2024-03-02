using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlackObjectController : MonoBehaviour
{
    private Animator _animator;
    public SkinnedMeshRenderer _meshRenderer;
    private Transform _playerTransform;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        AnimSpeedUp();
    }

    void AnimSpeedUp()
    {
        _animator.speed = 1;
    }

    private void StartChasingSetting()
    {
        _meshRenderer.enabled = true;
        _animator.applyRootMotion = true;
    }
    public IEnumerator ChasingPlayer(Transform player)
    {
        Debug.Log("Start Chasing Player");
        _playerTransform = player;
        StartChasingSetting();
        
        float lookAtTime = 0.5f;
        while (true)
        {
            Vector3 targetVector =
                new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.DOLookAt(targetVector, lookAtTime, AxisConstraint.None);
            yield return new WaitForSeconds(0.5f);
            // break;
        }

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(ChasingPlayer(_playerTransform));
            Debug.Log("The Black Got a Player");
        }
    }
}