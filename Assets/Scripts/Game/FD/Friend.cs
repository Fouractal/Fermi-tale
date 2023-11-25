﻿using System.Collections;
using UnityEngine;

public class Friend : MonoBehaviour//, Interactable
{
    private Rigidbody _rigidbody;
    private Transform _target;
    private bool is_following = false;

    public float speed;
    public float followThreshold;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _target = PlayerCharacterManager.Instance.player.transform;
    }
    
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) Interaction();

        if (!is_following) return;
        
        float dist = Vector3.Distance(_target.position, transform.position);
        if (dist < followThreshold) return;
        
        _rigidbody.position += (_target.position - transform.position).normalized * speed * Time.deltaTime;
        transform.LookAt(_target.position);
    }

    public void Interaction()
    {
        is_following = !is_following;
    }
}