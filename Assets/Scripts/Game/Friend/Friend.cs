using System.Collections;
using UnityEngine;

public class Friend : MonoBehaviour, IInteractable
{
    private Rigidbody _rigidbody;
    private Transform _target;
    private bool is_following = false;

    public float speed;
    public float followThreshold;

    public Animator animator;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _target = PlayerManager.Instance.player.transform;
        animator.SetBool("isWalking", false);
    }
    
    public void Update()
    {
        if (!is_following)
            return;
        
        float dist = Vector3.Distance(_target.position, transform.position);
        if (dist < followThreshold)
        {
            animator.SetBool("isWalking", false);
            return;
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
        
        _rigidbody.position += (_target.position - transform.position).normalized * speed * Time.deltaTime;
        transform.LookAt(_target.position);
    }

    public void Interaction()
    {
        is_following = !is_following;
    }
}