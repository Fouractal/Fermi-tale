using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RootObject : MonoBehaviour
{
    private void Awake()
    {
        Register();
    }
    
    protected abstract void Register();
}
