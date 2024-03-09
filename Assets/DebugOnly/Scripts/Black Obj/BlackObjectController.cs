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

    private IEnumerator BGObjectIsHit(GameObject BGObject)
    {
        Debug.Log($"{BGObject.name} is Hit");
        yield return new WaitForSeconds(2f);

        /*BGObject.GetComponent<Collider>().enabled = false;
        Rigidbody rb = BGObject.GetComponent<Rigidbody>(); 
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;*/
        Destroy(BGObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 30)
        {
            StartCoroutine(BGObjectIsHit(collision.gameObject));
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(ChasingPlayer(_playerTransform));
            Debug.Log("The Black Got a Player");
        }
    }
    
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(ChasingPlayer(_playerTransform));
            Debug.Log("The Black Got a Player");
        }
    }*/ 
}