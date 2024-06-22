using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game.FM;
using TMPro;
using UnityEngine;

public class FM_Item : MonoBehaviour
{
    public FM_GameFramework fmGameFramework;
    public int itemIndex;
    public bool isCollected = false;
    public string nonCollectedMessage;
    public string collectedMessage;
    public TextMeshProUGUI text;
    public Vector3 originalPosition;
    private void Awake()
    {
        originalPosition = text.transform.localPosition;
        isCollected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isCollected) return;
        if (other.transform.root.CompareTag("Player"))
            fmGameFramework.Success(itemIndex);

        isCollected = true;
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
            sequence.Append(text.transform.DOLocalMoveY(originalPosition.y + riseDistance, duration)
                .SetEase(Ease.OutQuad));
            sequence.Join(text.DOFade(0, duration));
            
            // 애니메이션이 완료될 때까지 대기
            yield return sequence.WaitForCompletion();

            if (itemIndex != 3)
            {
                if (fmGameFramework.successNumber >= 3)
                {
                    text.text = "";
                    text.DOKill();
                    yield break;
                }    
            }
            else
            {
                if (fmGameFramework.successNumber >= 4)
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
