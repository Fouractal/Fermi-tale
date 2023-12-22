using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class Rose : MonoBehaviour
{
    public int ownIndex;

    private bool _isFlying = false;
    
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
        if (_isFlying == false && other.CompareTag("Player"))
        {
            _isFlying = true;
            RoseContainer.ShowRose(ownIndex+1);    
        }
        else if (_isFlying && other.CompareTag("Rose"))
        {
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
        _isFlying = false;

        Vector3 endPos = RoseContainer.GetRose(ownIndex + 1).transform.position;
        
        Sequence sequence = DOTween.Sequence();

        sequence
            .Append(transform.DOJump(endPos,2f, 1, 2f))
            .AppendCallback(() => Destroy(gameObject));
    }

    public void LeadToNextRose()
    {
        Rose targetRose = RoseContainer.GetRose(ownIndex + 1);

        Vector3 dir = (targetRose.transform.position - PlayerCharacterManager.Instance.player.transform.position).normalized * 3;
        Vector3 movement = new Vector3(Mathf.Sin(Time.time * 2.5f), Mathf.Cos(Time.time * 3), Mathf.Sin(Time.time * 3.3f)) * 0.5f + Vector3.up;

        transform.position = PlayerCharacterManager.Instance.player.transform.position + dir + movement;
    }

    public void Update()
    {
        if(_isFlying) LeadToNextRose();
    }
}
