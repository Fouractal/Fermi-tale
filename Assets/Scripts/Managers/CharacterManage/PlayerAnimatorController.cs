using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    // animation 종류
    // Walk (Blend Tree를 사용해 터치 입력에 따라 애니메이션 혼합)
    // Run 
    // Taking Item (아이템을 줍고 살펴 봄)
    // Using A Filling Cabinet (서랍을 열고 뒤적뒤적하다 아이템을 잡고 꺼냄)
    // Sitting (플레이어 기준 바로 뒤에 있는 의자에 털썩 앉는다)
    // Standing Greeting (정면을 보고 손을 흔들며 인사를 한다.)
    // Standing Idle (기본 서있는 자세, 약간 짝다리)
    // Surprised (서양식 놀람, )
    // Pull the Door Open by Right Hand (오른손으로 잡아 당겨 문을 염)
    // Open lower Cabinet (아래에 있는 선반을 열고 뒤지다가 찾음. 그리고 닫고 일어난 후에 쳐다 봄)
    // Push Start (무거운 물체를 힘들게 밀어냄)
    // Push (밀면서 앞으로 감)
    // Dig And Plant Seeds (흙을 파내고 씨앗을 넣고 흙을 덮음)
    
    
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // 트리거되면 PlayerAnimatorController 조작
    // 외부에서 여기 접근해서 animator.setbool float
}
