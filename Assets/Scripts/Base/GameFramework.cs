using System.Collections;
using UnityEngine;

public abstract class GameFramework
{
    protected Coroutine gameFramework = null;
    protected abstract IEnumerator GameFrameworkCoroutine();
}
