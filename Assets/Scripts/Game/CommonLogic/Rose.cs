using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class Rose : MonoBehaviour
{
    private static Queue<Rose> roseQueue = new Queue<Rose>();

    private void Awake()
    {
        roseQueue.Enqueue(this);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Show();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowNextRose();
            Hide();
        }
    }

    public void Show()
    {
        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(transform.DOScale(Vector3.one, 1f));
    }

    public void Hide()
    {
        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(transform.DOScale(Vector3.zero, 1f))
            .AppendCallback(() => Destroy(gameObject));
    }

    public static void ShowNextRose()
    {
        if (roseQueue.Count == 0) return;
        roseQueue.Dequeue().gameObject.SetActive(true);
    }
}
