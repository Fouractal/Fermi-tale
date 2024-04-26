using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static IInteractable _item;
    
    public static void RegisterItem(IInteractable item)
    {
        _item = item;
    }

    public static void DeregisterItem()
    {
        _item = null;
    }
}
