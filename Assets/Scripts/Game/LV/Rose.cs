using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.LV
{
    public class Rose : MonoBehaviour, IInteractable
    {
        private Quest _quest = LV.Quest.None;
        private QuestUI _questUI;
        private Timer _timer;
        
        public delegate void QuestHandler(Rose rose);
        public static event QuestHandler OnQuestStart;
        public static event QuestHandler OnQuestSuccess;
        public static event QuestHandler OnQuestFail;

        private void Awake()
        {
            _timer = gameObject.AddComponent<Timer>();
        }

        private void Start()
        {
            var gf = GameManager.Instance.GameFramework as LV_GameFramework;
            if (gf != null) gf.RegisterRose(this);
        }
        
        public void StartQuest()
        {
            StartCoroutine(QuestRoutine());
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
            
            OnQuestSuccess?.Invoke(this);
        }

        private void QuestFail()
        {
            Debug.Log("Quest Fail...");
            _quest = Quest.None;
            _questUI.HideQuestUI();
            
            OnQuestFail?.Invoke(this);
        }

        public void Interaction()
        {
            Debug.Log("RoseInteraction");
            if (_quest == Quest.Cleaning && Inventory.Item is Towel) QuestSuccess();
            if (_quest == Quest.Fertilizing && Inventory.Item is Fertilizer) QuestSuccess();
            if (_quest == Quest.Watering && Inventory.Item is WateringCan) QuestSuccess();
            if (_quest == Quest.RemoveBugs && Inventory.Item is GlassCover) QuestSuccess();
        }
    }
}
