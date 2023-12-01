using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class HugeClock : MonoBehaviour
{
    [Header("ClockHand")]
    public ClockHand hourHand;
    public ClockHand minuteHand;
    
    public Transform hourHandTransform;
    public Transform minuteHandTransform;

    [Header("Data")]
    private int _time;
    public int Time
    {
        get => _time;
        set => _time = value % (12 * 12);
    }
    
    public AudioSource audioSource;

    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
        StartCoroutine(Ticktock());
    }

    private void Start()
    {
        //ClockHand.OnClockHandsOverlap += Alert;
    }

    public IEnumerator Ticktock()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            Time++;

            Sequence sequence = DOTween.Sequence();
            sequence
                .Append(minuteHandTransform.DOLocalRotate(Vector3.up * Time * 30, 0.5f).SetEase(Ease.OutCubic))
                .Join(hourHandTransform.DOLocalRotate(Vector3.up * Time * 2.5f, 0.5f).SetEase(Ease.OutCubic))
                .AppendCallback(ClockHand.CheckClockHandOverlap);
        }
    }
    
    public void Alert(int count)
    {
        audioSource.clip = Resources.Load<AudioClip>("Sounds/FouractalClock1");
        audioSource.Play();
    }
}
