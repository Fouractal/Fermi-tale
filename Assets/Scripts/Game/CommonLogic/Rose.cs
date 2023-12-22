using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class Rose : MonoBehaviour
{
    public int ownIndex;
    
    private void Start()
    {
        RoseContainer.Register(this);
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
            RoseContainer.ShowRose(ownIndex+1);
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
}
