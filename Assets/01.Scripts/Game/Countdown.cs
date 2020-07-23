using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private bool playOnAwake;
    [SerializeField]
    private float interval;
    [SerializeField]
    private GameObject[] counts;
    [SerializeField]
    private VoidEvent onCountdown;

    public void Play()
    {
        foreach (var count in counts)
        {
            count.SetActive(false);
        }
        StartCoroutine(PlayCoroutine());
    }

    private void Awake()
    {
        if (playOnAwake)
        {
            Play();
        }
    }

    private IEnumerator PlayCoroutine()
    {
        for (int i = 0; i < counts.Length; i++)
        {
            counts[i].SetActive(true);
            yield return YieldInstructionCache.WaitingSeconds(interval);
            counts[i].SetActive(false);
        }
        onCountdown?.Invoke();
    }
}
