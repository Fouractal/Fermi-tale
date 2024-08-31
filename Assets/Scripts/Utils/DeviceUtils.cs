using UnityEngine;
using UnityEngine.EventSystems;

public class DeviceUtils
{
    public static void Haptic(PointerEventData eventData)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidUtils.Vibrate(20);       
#else
        Handheld.Vibrate();
#endif
    }
}