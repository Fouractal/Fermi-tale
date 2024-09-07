using System.Collections;
using System.Collections.Generic;
using Managers.GameManage;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameManager() {}

    public GameFlow GameFlow { get; set; }
    public GameScene GameScene { get; set; }
    public SceneFlow SceneFlow { get; set; }

    public InputManager PlayerController { get; set; }
    public PlayerManager PlayerManager { get; set; }
    public CameraManager CameraManager { get; set; }
}
