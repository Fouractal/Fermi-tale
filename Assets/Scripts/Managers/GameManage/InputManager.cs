using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private TouchPad touchPad;

    private PlayerController playerController;
    private CameraController cameraController;
    
    public void Start()
    {
        touchPad = TouchPad.Instance;

        playerController = new PlayerController(PlayerManager.Instance.player);
        touchPad.drag.OnDragStart += playerController.PosMark;
        touchPad.drag.OnWhileDrag += playerController.SetPlayerVelocity;
        touchPad.drag.OnDragDone += playerController.ResetPlayerVelocity;
        touchPad.longPress.OnLongPress += playerController.TryInteraction;
        
        cameraController = new CameraController(null);
        touchPad.doubleTap.OnDoubleTap += cameraController.CameraTurn;

        touchPad.longPress.OnLongPress += DeviceUtils.Haptic;
    }
}
