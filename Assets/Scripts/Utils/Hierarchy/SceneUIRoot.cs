using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUIRoot : RootObject
{
    public static Transform Transform;
      
    protected override void Register()
    {
        Transform = transform;
    }
}
