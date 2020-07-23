using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SelectWidget : UIWidget
{
    [Header("Objects")]    
    [SerializeField]
    private Image[] widgetItems;

    [Header("Events")]
    [SerializeField]
    private VoidEvent exitEvent;
    public override void Execute(){
        gameObject.SetActive(true);
        for(int i = 0; i < widgetItems.Length; i++){
            widgetItems[i].DOFade(1.0f, 0.5f);
        }
    }

    public override void Exit(){
        for(int i = 0; i < widgetItems.Length; i++){
            widgetItems[i].DOFade(1.0f, 0.5f);
        }
    }

    private IEnumerator ExitCoroutine(){
        for(int i = 0; i < widgetItems.Length - 1; i++){
            widgetItems[i].DOFade(1.0f, 0.5f);
        }

        Tween exitTween = widgetItems[widgetItems.Length - 1].DOFade(0.0f, 0.5f);
        yield return exitTween.WaitForCompletion();

        exitEvent.Invoke();
        gameObject.SetActive(false);
    }
}
