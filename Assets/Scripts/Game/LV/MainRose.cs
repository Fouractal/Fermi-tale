using UnityEngine;

namespace Game.LV
{
    public class MainRose : MonoBehaviour, IInteractable
    {
        public delegate void MainRoseInteractionHandler();
        public event MainRoseInteractionHandler OnInteraction;
    
        public void Interaction()
        {
            OnInteraction?.Invoke();
        }
    }
}
