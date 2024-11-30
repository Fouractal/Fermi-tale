using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Game.LV
{
    public class Rose : MonoBehaviour, IInteractable
    {
        private Quest _quest = LV.Quest.None;
        private QuestUI _questUI;
        private Timer _timer;
        private Coroutine _questRoutine;

        public delegate void QuestRoseHandler(Rose rose);
        public static event QuestRoseHandler OnQuestStart; 
        
        public delegate void QuestHandler();
        public static event QuestHandler OnQuestSuccess;
        public static event QuestHandler OnQuestFail;

        private void Awake()
        {
            _timer = gameObject.AddComponent<Timer>();
        }

        private void Start()
        {
            var gf = GameManager.Instance.SceneFlow as LoverSceneFlow;
            if (gf != null) gf.RegisterRose(this);
        }
        
        public void StartQuest()
        {
            if (_questRoutine != null) return;
            _questRoutine = StartCoroutine(QuestRoutine());
        }
        
        private IEnumerator QuestRoutine()
        {
            yield return new WaitForSecondsRealtime(Random.Range(0f, 5f));
            
            while (true)
            {
                _quest = (Quest)Random.Range(1, 5);
                _timer.OnNextTimeOver += QuestFail;
                _timer.StartTimer(30f);

                Vector3 curPos = transform.position;
                Vector3 targetPos = new Vector3(curPos.x, 8, curPos.z);
                _questUI = QuestUI.ShowQuestUI(targetPos, _quest);
                
                yield return new WaitUntil(() => _quest == Quest.None);
                yield return new WaitForSeconds(5f);
                
                // 제한시간 업데이트 또는 주기 업데이트
            }
        }

        private void QuestSuccess()
        {
            Debug.Log("Quest Success!");
            _timer.StopTimer();
            _quest = Quest.None;
            _questUI.HideQuestUI();
            
            GrowUp();
            
            OnQuestSuccess?.Invoke();
        }

        private void QuestFail()
        {
            Debug.Log("Quest Fail...");
            _quest = Quest.None;
            _questUI.HideQuestUI();
            
            OnQuestFail?.Invoke();
        }

        public void Interaction()
        {
            Debug.Log("RoseInteraction");
            if (_quest == Quest.Cleaning && Inventory.Item is Towel) QuestSuccess();
            if (_quest == Quest.Fertilizing && Inventory.Item is Fertilizer) QuestSuccess();
            if (_quest == Quest.Watering && Inventory.Item is WateringCan) QuestSuccess();
            if (_quest == Quest.RemoveBugs && Inventory.Item is GlassCover) QuestSuccess();
        }

        public void GrowUp()
        {
            transform.DOScale(transform.localScale + Vector3.one, 1f);
        }

        [ContextMenu("DebugSuccess")]
        public void DebugSuccess()
        {
            OnQuestSuccess?.Invoke();
        }

        [ContextMenu("DebugFail")]
        public void DebugFail()
        {
            OnQuestFail?.Invoke();
        }
    }
}
