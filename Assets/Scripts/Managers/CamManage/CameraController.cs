using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController
{
    private FermiCamera camera;

    public CameraController(FermiCamera camera)
    {
        this.camera = camera;
    }

    public void CameraTurn(PointerEventData eventData)
    {
        Debug.Log("CameraTurn");
        if (camera.isTurning) return;
        camera.isTurning = true;

        if (eventData.position.x <= 540)
        {
            camera.CameraTurnClockwise();
        }
        else
        {
            camera.CameraTurnCounterClockwise();
        }

        camera.isTurning = false;
    }
}
