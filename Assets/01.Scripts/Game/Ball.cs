using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Vector2 startPosition;

    private Tweener tween;
    private Sequence sequence;

    public void Throw()
    {
        sequence.Restart();
    }

    private void Start()
    {
        tween = image.rectTransform.DOAnchorPos(Vector2.zero, 0.5F);
        sequence = DOTween.Sequence()
                  .AppendCallback(() => image.rectTransform.anchoredPosition = startPosition)
                  .Append(tween)
                  .Join(image.DOFade(1F, 0.5F))
                  .Append(image.DOFade(0F, 0.1F))
                  .SetAutoKill(false);
    }
}
