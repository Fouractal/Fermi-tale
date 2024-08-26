using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FM_Item_Text : MonoBehaviour
{
    // Start is called before the first frame update
    public FM_Item fmItem;

    public string nonCollectedMessage;
    public string collectedMessage;
    public TextMeshProUGUI text;
    public bool isCollected = false;
    public Vector3 originalPosition;

    private void Awake()
    {
        fmItem = GetComponent<FM_Item>();
        originalPosition = text.transform.localPosition;
        
    }

    public IEnumerator TextRoutine()
    {
        float duration = 5f;
        float riseDistance = 50f;
        while (true)
        {
            // 상태에 따른 text 설정
            text.text = isCollected ? collectedMessage : nonCollectedMessage;

            // 초기 위치 및 알파 설정
            text.transform.localPosition = originalPosition;
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            
            // 텍스트가 떠오르고 사라지는 애니메이션
            Sequence sequence = DOTween.Sequence();
            sequence.Append(text.transform.DOLocalMoveY(originalPosition.y + riseDistance + Random.Range(-100,100), duration + Random.Range(-5,5))
                .SetEase(Ease.OutQuad));
            sequence.Join(text.DOFade(0, duration));
            
            // 애니메이션이 완료될 때까지 대기
            yield return sequence.WaitForCompletion();

            if (fmItem.itemIndex != 3)
            {
                if (fmItem.fmGameFramework.successNumber >= 3)
                {
                    text.text = "";
                    text.DOKill();
                    yield break;
                }    
            }
            else
            {
                if (fmItem.fmGameFramework.successNumber >= 4)
                {
                    Debug.Log("FM Last Object! FM End");
                    text.text = "";
                    text.DOKill();
                    yield break;
                }    
            }
            
        }
    }
}
