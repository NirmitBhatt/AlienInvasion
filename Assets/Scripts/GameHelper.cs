using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelper : MonoBehaviour
{
    public static GameHelper SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    public void DoSomethingAfterXSeconds(Action action, float seconds)
    {
        StartCoroutine(DoSomethingAfterXSecondsRoutine(action, seconds));
    }

    private IEnumerator DoSomethingAfterXSecondsRoutine(Action action, float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        action?.Invoke();
    }
}
