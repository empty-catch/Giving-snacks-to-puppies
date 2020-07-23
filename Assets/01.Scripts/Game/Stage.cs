using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Stage : Singleton<Stage>
{
    private static readonly float PlayTime = 60F;

    [SerializeField]
    private FloatEvent floatTimeRemainingChanged;
    [SerializeField]
    private StringEvent stringTimeRemainingChanged;
    [SerializeField]
    private StringEvent scoreChanged;

    private float timeRemaining = PlayTime;
    private int score;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreChanged?.Invoke($"찾은 강아지: {score:0} / 0 마리");
        }
    }

    private IEnumerator Start()
    {
        while (timeRemaining > 0F)
        {
            yield return null;
            timeRemaining -= Time.deltaTime;
            floatTimeRemainingChanged?.Invoke(timeRemaining / PlayTime);
            stringTimeRemainingChanged?.Invoke($"남은시간 {timeRemaining:00.00}");
        }

        floatTimeRemainingChanged?.Invoke(0F);
        stringTimeRemainingChanged?.Invoke("남은시간 00.00");
    }

    [Serializable]
    public class FloatEvent : UnityEvent<float> { }
    [Serializable]
    public class StringEvent : UnityEvent<string> { }
}
