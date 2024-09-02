using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.LV
{
    public abstract class Item : MonoBehaviour, IInteractable
    {
        public virtual void Interaction()
        {
            Debug.Log("Item Interaction");
            Inventory.Item = this;
        }
    }
    
}