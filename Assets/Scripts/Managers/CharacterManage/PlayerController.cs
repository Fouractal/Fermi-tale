using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _rigidbody;

    public Animator playerAnimator;
    public Vector2 direction;
    private float _angle = -45f; //회전할 각도 (단위: 도)
    private float _radians = 0f; // 각도를 라디안으로 변환
    void Start()
    {
        _radians = _angle * Mathf.Deg2Rad;
        _rigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public Vector3 ConvertXYtoXZ()
    {
        float x = direction.x;
        float y = direction.y;

        float newX = x * Mathf.Cos(_radians) - y * Mathf.Sin(_radians);
        float newZ = x * Mathf.Sin(_radians) + y * Mathf.Cos(_radians);
        
        return new Vector3(newX, 0f, newZ);
    }
    void Move()
    {
        // (x, y) direction Vector -> (45도 회전된) XZ 평면에서의 방향으로 변환
        _rigidbody.position += ConvertXYtoXZ() * speed * Time.fixedDeltaTime;
        transform.LookAt(transform.position + ConvertXYtoXZ());
        
        // (1,0)  -> (Vector3.back + Vector3.right) * speed
        // (-1,0) -> (Vector3.forward + Vector3.left) * speed
        // (0,1)  -> (Vector3.forward + Vector3.right) * speed
        // (0,-1) -> (Vector3.back + Vector3.left) * speed
    }
}
