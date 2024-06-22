using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.FM
{
    public class FM_GameFramework : GameFramework
    {
        public Phase phase = Phase.ConversationOne;
        public int successNumber;
        public bool[] isCollectedArray = new bool[4];
        public FM_Item[] items;
        void Start()
        {
           Init(); 
        }

        private void Init()
        {
            for (int i = 0; i < isCollectedArray.Length; i++)
                isCollectedArray[i] = false;
            
            successNumber = 0;
            phase = Phase.ConversationOne;
            StartCoroutine(GameFramework());
        }
        private IEnumerator GameFramework()
        {
            // TODO : Game 로직 추가하기
            // 가족들은 간접적으로 대화 중
            // 특정 대화와 일치하는 아이템이 맵에 존재
            // 해당 아이템 찾으면 해당 주제 클리어
            // 총 세 가지 대화 클리어 후 마지막 대화 주제가 남음

            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(items[i].TextRoutine());
            }
            yield return new WaitUntil(() => successNumber == 3);
            
            StartCoroutine(items[3].TextRoutine());
            yield return new WaitUntil(() => successNumber == 4);

            yield break;
        }

        public void Success(int itemIndex)
        {
            successNumber++;
            Debug.Log("Success Item Number " + successNumber);
        }
    }
}

