using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Dog : MonoBehaviour
{
    [SerializeField]
    private Image image;
    private Tween tween;
    private bool shouldRenew;

    public Image Image => image;
    public int Index { get; set; } = -1;

    public void Feed()
    {
        tween?.Kill();
        DOVirtual.DelayedCall(1F, () => shouldRenew = true).Play();

        if (DogFactory.MemoryContains(1 << Index))
        {
            Stage.instance.Score++;
        }
    }

    private IEnumerator Start()
    {
        while (true)
        {
            float waitingTime = Random.Range(2, 9);
            yield return YieldInstructionCache.WaitingSeconds(waitingTime);
            shouldRenew = false;

            DogFactory.SetRandomDog(this);
            image.DOFade(1F, 0.5F);
            tween = DOVirtual.DelayedCall(8F, () => shouldRenew = true).Play();

            yield return new WaitUntil(() => shouldRenew);
            image.DOFade(0F, 0.5F);
            tween.Kill();
            Index = -1;
        }
    }
}
