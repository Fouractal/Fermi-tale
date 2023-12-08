using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.GameFlow = this;
    }

    public void LoadNextScene(Define.FadeType fadeType)
    {
        IEnumerator LoadNextSceneRoutine()
        {
            Overlay.FadeOut(fadeType);
        
            yield return new WaitForSecondsRealtime(3f);
            int curSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(curSceneIndex + 1);
        
            yield return new WaitForSecondsRealtime(1f);
            Overlay.FadeIn();
        }

        StartCoroutine(LoadNextSceneRoutine());
    }
}