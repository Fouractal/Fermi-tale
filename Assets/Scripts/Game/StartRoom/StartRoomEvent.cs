using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class StartRoomEvent : MonoBehaviour
{
    [SerializeField] private DOTweenAnimation doorAnim;
    public EventArea doorEventArea;

    void Start()
    {
        doorEventArea.areaEventData.func = doorAnim.DORestart;

        AreaEventData test = new AreaEventData(Vector3.right * 100, 1f, ()=>Debug.Log("test"));
        EventManager.Instance.AddAreaEvent(test);
    }
}
