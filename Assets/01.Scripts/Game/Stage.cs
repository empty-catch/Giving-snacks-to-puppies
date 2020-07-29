using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Stage : Singleton<Stage>
{
    private static readonly float PlayTime = 60F;

    [SerializeField]
    private Transform dog;
    [SerializeField]
    private Transform dogMemory;
    [SerializeField]
    private FloatEvent floatTimeRemainingChanged;
    [SerializeField]
    private StringEvent stringTimeRemainingChanged;
    [SerializeField]
    private StringEvent scoreChanged;
    [SerializeField]
    private VoidEvent stageFinished;
    [SerializeField]
    private StringEvent finalScoreApplied;

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

    public void ActivateObjects()
    {
        dog.GetChild((int)GameManager.instance.StageDifficulty).gameObject.SetActive(true);
    }

    public void ActivateDogMemory()
    {
        dogMemory.GetChild((int)GameManager.instance.StageDifficulty).gameObject.SetActive(true);
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
        finalScoreApplied?.Invoke(Score.ToString());
        stageFinished?.Invoke();
    }

    [Serializable]
    public class FloatEvent : UnityEvent<float> { }
    [Serializable]
    public class StringEvent : UnityEvent<string> { }
}
