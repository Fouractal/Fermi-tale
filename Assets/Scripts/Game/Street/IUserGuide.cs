using UnityEngine;

public abstract class BaseInteractive : MonoBehaviour
{
    public abstract void ShowInstructions();  // 사용법 안내를 화면에 보여주는 메서드

    public abstract void PlayEffect(); // 연출 효과를 실행하는 메서드

    public abstract void StopEffect(); // 연출을 멈추는 메서드
    
    public abstract bool CheckIsGuideCompleted();  // 사용자가 안내를 모두 완료했는지 확인하는 메서드
}
// TODO : 추가로 구현하면 좋을 것?

// void ShowHint(string context);  // 특정 상황에 맞는 힌트를 제공하는 메서드