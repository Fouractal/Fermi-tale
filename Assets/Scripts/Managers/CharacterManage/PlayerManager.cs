using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public Player player;
    public InputManager playerController;

    private void Awake()
    {
        playerController = GetComponent<InputManager>();
    }
}
