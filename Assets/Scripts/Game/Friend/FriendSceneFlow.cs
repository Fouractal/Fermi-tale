using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FriendSceneFlow : SceneFlow
{
    public Define.FD_Phase Phase { get; set; }

    private List<Friend> friends = new List<Friend>();

    private void Awake()
    {
        GameManager.Instance.SceneFlow = this;
    }
    
    private void Start()
    {
        Phase = Define.FD_Phase.Start;
        ClockHandTrigger.OnClockHandsOverlap += CheckPhase;
        
        StartCoroutine(GameFramework());
    }

    private IEnumerator GameFramework()
    {
        yield return new WaitUntil(() => Phase == Define.FD_Phase.Childhood);
        SpawnFriend();
        InitFriendsPos();

        yield return new WaitUntil(() => Phase == Define.FD_Phase.Adolescence);
        SpawnFriend();
        InitFriendsPos();
        
        yield return new WaitUntil(() => Phase == Define.FD_Phase.Earlyadulthood);
        SpawnFriend();
        InitFriendsPos();
        
        yield return new WaitUntil(() => Phase == Define.FD_Phase.End);
        SpawnPortal();
    }

    private void SpawnFriend()
    {
        GameObject friendPrefab = Resources.Load<GameObject>("Prefabs/FD/Friend");
        Friend newFriend = Instantiate(friendPrefab, Vector3.back, Quaternion.identity).GetComponent<Friend>();
        friends.Add(newFriend);
    }

    private void InitFriendsPos()
    {
        
    }

    private void SpawnPortal()
    {
        GameObject portalPrefab = Resources.Load<GameObject>("Prefabs/Portal");
        Instantiate(portalPrefab, new Vector3(2, 1, -2), Quaternion.Euler(new Vector3(0f, 90f, 90f)));
    }

    private void CheckPhase(int overlapCount)
    {
        switch (Phase)
        {
            case Define.FD_Phase.Start:
                if (overlapCount == 2) Phase = Define.FD_Phase.Childhood;
                break;
            case Define.FD_Phase.Childhood:
                if (overlapCount == 3) Phase = Define.FD_Phase.Adolescence;
                break;
            case Define.FD_Phase.Adolescence:
                if (overlapCount == 4) Phase = Define.FD_Phase.Earlyadulthood;
                break;
            case Define.FD_Phase.Earlyadulthood:
                if (overlapCount == 5) Phase = Define.FD_Phase.End;
                break;
        }
    }
}