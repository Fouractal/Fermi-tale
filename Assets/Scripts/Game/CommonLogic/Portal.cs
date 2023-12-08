using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private bool _isInteractable = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _isInteractable)
        {
            _isInteractable = false;
            GameManager.Instance.GameFlow.LoadNextScene();
        }
    }
}
