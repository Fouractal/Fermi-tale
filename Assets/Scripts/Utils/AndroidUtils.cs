using UnityEngine;

public class AndroidUtils
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass AndroidPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject AndroidcurrentActivity = AndroidPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject AndroidVibrator = AndroidcurrentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

    public static void Vibrate()
    {
        AndroidVibrator.Call("vibrate");
    }
 
    public static void Vibrate(long milliseconds)
    {
        AndroidVibrator.Call("vibrate", milliseconds);
    }
    public static void Vibrate(long[] pattern, int repeat)
    {
        AndroidVibrator.Call("vibrate", pattern, repeat);
    }
 
    public static void Cancel()
    {
        AndroidVibrator.Call("cancel");
    }
#endif
}