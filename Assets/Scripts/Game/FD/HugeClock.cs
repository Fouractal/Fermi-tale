using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class HugeClock : MonoBehaviour
{
    [Header("Object")]
    public GameObject hourHand;
    public GameObject minuteHand;

    [Header("Data")]
    public float areaSize;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Ticktock());
    }

    public void Alert()
    {
        audioSource.clip = Resources.Load<AudioClip>("Sounds/FouractalClock1");
        audioSource.Play();
    }

    public IEnumerator Ticktock()
    {
        int time = 0;

        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            time++;
            time %= 12 * 12;
            
            Sequence sequence = DOTween.Sequence();
            sequence
                .Append(minuteHand.transform.DOLocalRotate(Vector3.up * time * 30, 0.5f).SetEase(Ease.OutCubic))
                .Join(hourHand.transform.DOLocalRotate(Vector3.up * time * 2.5f, 0.5f).SetEase(Ease.OutCubic));
        }
    }
    
}
