using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUIRoot : RootObject
{
    public static Transform Transform;
      
    protected override void Register()
    {
        Transform = transform;
    }
}
