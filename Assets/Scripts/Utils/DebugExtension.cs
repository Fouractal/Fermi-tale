public static class DebugExtension
{
    [System.Diagnostics.Conditional("DEVELOPMENT_BUILD")]
    public static void Log(this object value)
    {
#if DEVELOPMENT_BUILD
        string curSceneName = SceneManager.GetActiveScene().name;
        string prevClassName = new StackTrace().GetFrame(1).GetMethod().ReflectedType?.Name;

        UnityEngine.Debug.Log($"Fermi-tale : {curSceneName} : {prevClassName} : {value}");
#endif    
    }
    
    [System.Diagnostics.Conditional("DEVELOPMENT_BUILD")]
    public static void LogError(this object value)
    {
#if DEVELOPMENT_BUILD
        string curSceneName = SceneManager.GetActiveScene().name;
        string prevClassName = new StackTrace().GetFrame(1).GetMethod().ReflectedType?.Name;
            
        UnityEngine.Debug.LogError($"Fermi-tale : {curSceneName} : {prevClassName} : {value}");
#endif    
    }
}