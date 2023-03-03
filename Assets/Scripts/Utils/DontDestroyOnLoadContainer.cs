using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadContainer : Singleton<DontDestroyOnLoadContainer>
{ 
    private void Awake()
    {
        base.Awake(); 
        DontDestroyOnLoad(gameObject);
    }
}
