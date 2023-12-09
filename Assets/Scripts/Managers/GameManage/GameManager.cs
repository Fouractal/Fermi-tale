using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameManager() {}
    public GameFlow GameFlow { get; set; }
    public GameFramework GameFramework { get; set; }
}
