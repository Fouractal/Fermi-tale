using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugText : Singleton<DebugText>
{
    [SerializeField]
    private Text logText;

    private void Awake()
    {
        logText = GetComponent<Text>();
    }

    public void SetText(string txt)
    {
        logText.text = txt;
    }

    public void AddText(string txt)
    {
        logText.text += $"\n{txt}";
    }

    public void SetDebugTextCanvas()
    {
        var canvas = transform.parent.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;
    }

    private void Start()
    {
        SetDebugTextCanvas();
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            SetDebugTextCanvas();
        };
    }
}