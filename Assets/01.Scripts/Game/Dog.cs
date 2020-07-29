using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Dog : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Image sign;
    [SerializeField]
    private Sprite oSign;
    [SerializeField]
    private Sprite xSign;

    private Tween tween;
    private Sequence sequence;
    private bool shouldRenew;

    public Image Image => image;
    public int Index { get; set; } = -1;

    public void Feed()
    {
        tween?.Kill();
        DOVirtual.DelayedCall(1F, () => shouldRenew = true).Play();

        if (DogFactory.MemoryContains(Index))
        {
            DOVirtual.DelayedCall(0.5F, () => Stage.instance.Score++).Play();
            sign.sprite = oSign;
        }
        else
        {
            sign.sprite = xSign;
        }

        sequence.Restart();
    }

    private IEnumerator Start()
    {
        sequence = DOTween.Sequence()
                  .AppendCallback(() => sign.color = Color.clear)
                  .AppendInterval(0.5F)
                  .AppendCallback(() =>
                  {
                      sign.SetNativeSize();
                      sign.color = Color.white;
                  })
                  .AppendInterval(0.5F)
                  .Append(sign.DOFade(0F, 0.5F))
                  .SetAutoKill(false);

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
