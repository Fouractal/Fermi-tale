using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlackObjectController : MonoBehaviour
{
    public Animator animator;
    private Transform _playerTransform;

    private void Start()
    {
        animator = GetComponent<Animator>();
        AnimSpeedUp();
    }

    void AnimSpeedUp()
    {
        animator.speed = 1;
    }


    public IEnumerator ChasingPlayer(Transform player)
    {
        Debug.Log("Start Chasing Player");
        _playerTransform = player;
        //
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