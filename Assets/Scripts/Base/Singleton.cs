using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            Init();
            return _instance;
        }
    }

    private static void Init()
    {
        if(_instance != null)
        {
            return;
        }
        else
        {
            _instance = GameObject.FindObjectOfType<T>();
            
            if(_instance == null)
            {
                GameObject obj = new GameObject(typeof(T).Name);
                _instance = obj.AddComponent<T>();    
            }
        }
    }

    protected virtual void Awake()
    {
        if(gameObject != Instance.gameObject)
        {
            Debug.Log("is Duplicated");
            Destroy(gameObject);
        }
    }
}