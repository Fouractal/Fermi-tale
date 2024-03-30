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
        
        private int _successCount = 0;
        private int _failCount = 0;

        private int SuccessCount
        {
            get { return _successCount; }
            set
            {
                _successCount = value;
                
                if (_successCount > 0) _phase = Phase.AddOrder;
                if (_successCount > 10) _phase = Phase.TooMuchOrder;
            }
        }

        private int FailCount
        {
            get { return _failCount; }
            set
            {
                _failCount = value;
                
                SetDark();
                if (_failCount > 20) _phase = Phase.Darkness;
            }
        }
        
        private void Awake()
        {
            GameManager.Instance.GameFramework = this;
        }

        private void Start()
        {
            Rose.OnQuestStart += (GameManager.Instance.GameScene as LV_Scene).GenerateRoseQuestUI;
            StartCoroutine(GameFramework());
        }

        private IEnumerator GameFramework()
        {
            yield return new WaitUntil(() => _phase == Phase.OneOrder);
            var newQuestRose = Utils.SelectRandom<Rose>(roses);
            newQuestRose.StartQuest();
            
            yield return new WaitUntil(() => _phase == Phase.AddOrder);
            
            
            yield return new WaitUntil(() => _phase == Phase.TooMuchOrder);

            yield return new WaitUntil(() => _phase == Phase.Darkness);
        }

        private void SetDark()
        {
            
        }

        public void RegisterRose(Rose rose)
        {
            roses.Add(rose);
        }
    }
}