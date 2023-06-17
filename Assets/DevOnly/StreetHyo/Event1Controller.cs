using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Event1Controller : MonoBehaviour
{
    public InteractableObject interactableObject;
    void Awake()
    {
        // 이벤트 핸들러 등록
        interactableObject.OnInteract += MouseReaction;
        interactableObject.OnMove += HandleMove;
    }

    private void MouseReaction()
    {
        // 코루틴으로 랜덤 위치, 일정 시간동안 이동
        Vector3 endPosition = new Vector3(transform.position.x + Random.Range(-3f,3f), 0f, transform.position.z + Random.Range(-3f,3f));
        StartCoroutine(RandomPosition(endPosition,Random.Range(1f,2f)));
    }

    public IEnumerator RandomPosition(Vector3 endPos,float duration)
    {
        Debug.Log("move random positions");
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            transform.position = Vector3.Lerp(startPosition, endPos, t);
            yield return null;
        }
    }

    IEnumerator move()
    {
        Debug.Log("move");
        float duration = 2f;
        float elapsed = 0f;
        float speed = 1f;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = new Vector3(0f, 0f, 5f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }
    }
    private IEnumerator HandleMove()
    {
        // 이동 로직
        Debug.Log("move forward");
        yield return StartCoroutine(move());
    }
}
