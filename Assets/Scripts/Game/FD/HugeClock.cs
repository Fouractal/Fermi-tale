using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class HugeClock : MonoBehaviour
{
    public Transform hourHandTransform;
    public Transform minuteHandTransform;

    [Header("Data")]
    private int _time;
    public int Time
    {
        get => _time;
        set => _time = value % (12 * 12);
    }
    
    public AudioSource ticktockAudioSource;
    public AudioSource eventAudioSource;

    

    private void Awake()
    {
        StartCoroutine(Ticktock());
    }

    private void Start()
    {
        ClockHandTrigger.OnClockHandsOverlap += Alert;
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
                .AppendCallback(ClockHandTrigger.CheckClockHandOverlap);
        }
    }
    
    public void Alert(int overlapCount)
    {
        eventAudioSource.clip = Resources.Load<AudioClip>($"Sounds/FD/FouractalClock{overlapCount}");
        eventAudioSource.Play();
    }
}
