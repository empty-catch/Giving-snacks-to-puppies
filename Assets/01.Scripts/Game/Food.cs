using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Food : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image food;
    [SerializeField]
    private VoidEvent foodGiven;

    private Sequence sequence;

    public void OnPointerClick(PointerEventData _)
    {
        if (!sequence.IsPlaying())
        {
            sequence.Restart();
        }
    }

    private void Start()
    {
        sequence = DOTween.Sequence()
                  .AppendCallback(() => foodGiven?.Invoke())
                  .AppendInterval(0.5F)
                  .Append(food.rectTransform.DOAnchorPosY(-200F, 0.5F).SetEase(Ease.InQuad))
                  .Append(food.DOFade(0F, 0.5F))
                  .AppendInterval(0.5F)
                  .AppendCallback(() => food.rectTransform.anchoredPosition = Vector2.zero)
                  .Append(food.DOFade(1F, 0.1F))
                  .SetAutoKill(false);
    }
}
