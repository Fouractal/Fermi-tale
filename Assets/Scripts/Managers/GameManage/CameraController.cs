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
        if (camera.IsTurning) return;
        camera.IsTurning = true;

        if (eventData.position.x <= 540)
        {
            camera.CameraTurnCounterClockwise();
        }
        else
        {
            camera.CameraTurnClockwise();
        }

        camera.IsTurning = false;
    }
}
