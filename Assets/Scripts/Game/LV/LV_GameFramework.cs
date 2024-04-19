using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.LV
{
    public class LV_GameFramework : GameFramework
    {
        public Phase _phase = Phase.OneOrder;

        [SerializeField]
        private List<Rose> roses = new List<Rose>();
        private Garden _garden;
        
        [SerializeField]
        private int _successCount = 0;
        [SerializeField]
        private int _failCount = 0;
        
        private void Awake()
        {
            GameManager.Instance.GameFramework = this;
        }

        private void Start()
        {
            Rose.OnQuestStart += (GameManager.Instance.GameScene as LV_Scene).GenerateRoseQuestUI;
            
            Rose.OnQuestSuccess += IncreaseSuccessCount;
            Rose.OnQuestSuccess += CheckGamePhase;
            
            Rose.OnQuestFail += IncreaseFailCount;
            Rose.OnQuestFail += CheckGamePhase;
            Rose.OnQuestFail += SetScreenDarker;
            
            StartCoroutine(GameFramework());
        }

        private IEnumerator GameFramework()
        {
            yield return new WaitUntil(() => _phase == Phase.OneOrder);
            Debug.Log($"Phase : {_phase.ToString()}");
            var newQuestRose = Utils.SelectRandom<Rose>(roses);
            newQuestRose.StartQuest();
            
            yield return new WaitUntil(() => _phase == Phase.AddOrder);
            Debug.Log($"Phase : {_phase.ToString()}");
            foreach (var rose in Utils.SelectRandom(roses, 3))
            {
                rose.StartQuest();
            }
            
            yield return new WaitUntil(() => _phase == Phase.TooMuchOrder);
            Debug.Log($"Phase : {_phase.ToString()}");
            foreach (var rose in roses)
            {
                rose.StartQuest();
            }

            yield return new WaitUntil(() => _phase == Phase.Darkness);
            Debug.Log($"Phase : {_phase.ToString()}");
        }

        private void IncreaseSuccessCount()
        {
            _successCount++;
        }

        private void IncreaseFailCount()
        {
            _failCount++;
        }
        
        private void CheckGamePhase()
        {
            if (_successCount > 0) _phase = Phase.AddOrder;
            if (_successCount > 5) _phase = Phase.TooMuchOrder;
            if (_failCount > 5) _phase = Phase.Darkness;
            
            Debug.Log($"Phase : {_phase.ToString()}");
        }

        private void SetScreenDarker()
        {
            
        }

        public void RegisterRose(Rose rose)
        {
            roses.Add(rose);
        }
    }
}