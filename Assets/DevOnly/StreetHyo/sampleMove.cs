using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sampleMove : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.position += Vector3.forward * speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.position += Vector3.left * speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.position += Vector3.back * speed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.position += Vector3.right * speed * Time.fixedDeltaTime;
        }
    }
}
