using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.LV
{
    public class LV_GameFramework : GameFramework
    {
        public Phase _phase = Phase.OneOrder;

        [SerializeField]
        private List<Rose> questRoses = new List<Rose>();
        [SerializeField]
        private List<GameObject> roadRoses = new List<GameObject>();
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
            Rose.OnQuestSuccess += () => _successCount++;
            Rose.OnQuestSuccess += CheckGamePhase;

            Rose.OnQuestFail += () => _failCount++;
            Rose.OnQuestFail += CheckGamePhase;
            Rose.OnQuestFail += (GameManager.Instance.GameScene as LV_Scene).SetScreenDarker;
            
            StartCoroutine(GameFramework());
        }

        private IEnumerator GameFramework()
        {
            yield return new WaitUntil(() => _phase == Phase.OneOrder);

            var newQuestRose = Utils.SelectRandom<Rose>(questRoses);
            newQuestRose.StartQuest();
            
            yield return new WaitUntil(() => _phase == Phase.AddOrder);

            foreach (var rose in Utils.SelectRandom(questRoses, 3))
            {
                rose.StartQuest();
            }
            
            yield return new WaitUntil(() => _phase == Phase.TooMuchOrder);

            foreach (var rose in questRoses)
            {
                rose.StartQuest();
            }

            yield return new WaitUntil(() => _phase == Phase.Darkness);
            yield return new WaitForSecondsRealtime(2f);
            HideSubRoses();
            ShowMainRose();
            yield return new WaitForSecondsRealtime(1f);
            (GameManager.Instance.GameScene as LV_Scene).SetScreenBrighter();
        }
        
        private void CheckGamePhase()
        {
            if (_successCount >= 1) _phase = Phase.AddOrder;
            if (_successCount >= 5) _phase = Phase.TooMuchOrder;
            if (_failCount >= 10) _phase = Phase.Darkness;
        }

        public void RegisterRose(Rose rose)
        {
            questRoses.Add(rose);
        }

        private void HideSubRoses()
        {
            foreach (var rose in questRoses)
            {
                rose.gameObject.SetActive(false);
            }
        }

        private void ShowMainRose()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/LV/MainRose");
            MainRose mainRose = Instantiate(prefab).GetComponent<MainRose>();

            PlayerCharacterManager.Instance.player.transform.position = new Vector3(2, 5, -2);
            
            mainRose.OnInteraction += RoseRoadSequence;
        }

        private void RoseRoadSequence()
        {
            foreach (var rose in roadRoses)
            {
                rose.gameObject.SetActive(true);
            }
        }
    }
}