using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.FM
{
    public class FM_GameFramework : GameFramework
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(GameFramework());
        }

        private IEnumerator GameFramework()
        {
            // TODO : Game 로직 추가하기
            // 가족들은 간접적으로 대화 중
            // 특정 대화와 일치하는 아이템이 맵에 존재
            // 해당 아이템 찾으면 해당 주제 클리어
            // 총 세 가지 대화 클리어 후 마지막 대화 주제가 남음
            yield break;
        }
    }
}

