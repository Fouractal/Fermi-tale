using UnityEngine;

namespace Managers.GameManage
{
    public class GameScene : MonoBehaviour
    {
        protected virtual void Awake()
        {
            GameManager.Instance.GameScene = this;
        }

        protected virtual void Start()
        {
            // GameManager.Instance.GameFlow.PrepareNextScene(); // TODO
        }
    }
}