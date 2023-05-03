using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

    }
    
    
    private void MoveUp()
    {
        gameObject.transform.position += Vector3.left * speed;
    }
    
    private void MoveDown()
    {
        gameObject.transform.position += Vector3.left * speed;
    }

    private void MoveLeft()
    {
        gameObject.transform.position += Vector3.left * speed;
    }
    
    private void MoveRight()
    {
        gameObject.transform.position += Vector3.right * speed;
    }
}
