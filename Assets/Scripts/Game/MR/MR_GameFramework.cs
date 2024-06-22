using UnityEngine;

namespace Game.MR
{
    public class MR_GameFramework : GameFramework
    {
        private void Awake()
        {
            GameManager.Instance.GameFramework = this;
        }
    }
}
