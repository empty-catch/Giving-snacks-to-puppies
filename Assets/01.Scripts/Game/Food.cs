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
    [SerializeField]
    private VoidEvent foodFallen;

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
                  .Append(food.rectTransform.DOAnchorPosY(-200F, 0.5F).SetEase(Ease.InQuad))
                  .AppendCallback(() => foodFallen?.Invoke())
                  .Append(food.DOFade(0F, 0.5F))
                  .AppendInterval(0.5F)
                  .AppendCallback(() =>
                  {
                      food.color = Color.white;
                      food.rectTransform.anchoredPosition = Vector2.zero;
                  })
                  .SetAutoKill(false);
    }
}
