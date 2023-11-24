using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeClock : MonoBehaviour
{
    [Header("Object")]
    public GameObject hourHand;
    public GameObject minuteHand;

    [Header("Data")]
    public float speed;
    public float areaSize;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void Update()
    {
        minuteHand.transform.Rotate(Vector3.up * speed / 60 * Time.deltaTime);
        hourHand.transform.Rotate(Vector3.up * speed / 3600 * Time.deltaTime);
    }

    public void Alert()
    {
        audioSource.clip = Resources.Load<AudioClip>("Sounds/FouractalClock1");
        audioSource.Play();
    }
    
}
