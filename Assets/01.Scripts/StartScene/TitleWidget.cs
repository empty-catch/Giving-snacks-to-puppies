using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleWidget : UIWidget
{    
    [Header("Objects")]
    [SerializeField]
    private Image titleImage;

    [SerializeField]
    private Image buttonImage;

    [Header("Events")]
    [SerializeField]
    private VoidEvent closeEvents;

    public override void Execute(){
        FillCoroutine().Start(this);
    }

    private IEnumerator FillCoroutine(){
        titleImage.DOFade(1.0f, 0.3f);
        Tween amountTween = titleImage.DOFillAmount(1.0f, 0.5f);

        yield return amountTween.WaitForCompletion();
        
        buttonImage.DOFade(1.0f, 0.3f);
        buttonImage.DOFillAmount(1.0f, 0.5f);
    }

    public override void Exit(){
        CloseCoroutine().Start(this);
    }

    private IEnumerator CloseCoroutine(){
        titleImage.DOFade(0.0f, 0.5f);
        Tween fadeTween = buttonImage.DOFade(0.0f, 0.5f);

        yield return fadeTween.WaitForCompletion();

        gameObject.SetActive(false);
        closeEvents.Invoke();
    }
}
