using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Animator playerAnimator;
    
    public Vector3 velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    public void MoveBlend(float value)
    {
        playerAnimator.applyRootMotion = value == 0 ? true : false;
        playerAnimator.SetFloat("MoveBlend", value);
    }

    private void Move()
    {
        _rigidbody.position += velocity * Time.fixedDeltaTime;
        transform.LookAt(transform.position + velocity.normalized);
    }
}
