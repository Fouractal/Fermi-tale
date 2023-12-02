using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private Coroutine sceneChangeRoutine = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && sceneChangeRoutine == null)
        {
            sceneChangeRoutine = StartCoroutine(JoinNextScene());
        }
    }

    private IEnumerator JoinNextScene()
    {
        yield return new WaitForSecondsRealtime(3f);
        int curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curSceneIndex + 1);
    }
}
