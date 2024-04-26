using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.LV
{
    public class Item : MonoBehaviour, IInteractable
    {
        private bool _isUsing = false;
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
    
        public void Interaction()
        {
            if (_isUsing) return;
            Take();
        }

        public void Take()
        {
            _isUsing = true;
            _meshRenderer.enabled = false;
        }

        public void PutDown()
        {
            _isUsing = false;
            _meshRenderer.enabled = true;
        }
    }
    
}