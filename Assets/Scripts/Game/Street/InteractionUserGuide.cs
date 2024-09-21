using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUserGuide : MonoBehaviour, IUserGuide
{


    public void ShowInstructions()
    {
        // 사용법 안내를 화면에 보여주는 메서드 
    }  

    public void PlayEffect()
    {
        // 연출 효과를 실행하는 메서드  
    }

    public void StopEffect()
    {
        // 연출을 멈추는 메서드  
    }

    public bool IsGuideCompleted()
    {
        // 사용자가 안내를 모두 완료했는지 확인하는 메서드


        return false;
    }  
}
