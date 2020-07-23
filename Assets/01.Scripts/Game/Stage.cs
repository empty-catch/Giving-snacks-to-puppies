using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Stage : Singleton<Stage>
{
    private static readonly float PlayTime = 20F;

    [SerializeField]
    private FloatEvent floatTimeRemainingChanged;
    [SerializeField]
    private StringEvent stringTimeRemainingChanged;

    private float timeRemaining = PlayTime;
    public int Score { get; set; }

    private IEnumerator Start()
    {
        while (timeRemaining > 0F)
        {
            yield return null;
            timeRemaining -= Time.deltaTime;
            floatTimeRemainingChanged?.Invoke(timeRemaining / PlayTime);
            stringTimeRemainingChanged?.Invoke(timeRemaining.ToString("0.00"));
        }

        floatTimeRemainingChanged?.Invoke(0F);
        stringTimeRemainingChanged?.Invoke("0.00");
    }

    [Serializable]
    public class FloatEvent : UnityEvent<float> { }
    [Serializable]
    public class StringEvent : UnityEvent<string> { }
}
