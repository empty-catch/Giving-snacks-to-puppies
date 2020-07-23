using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private UIWidget titlePanel;

    [SerializeField]
    private UIWidget selectPanel;

    [SerializeField]
    private Image blackImage;

    private void Start(){
        titlePanel.Execute();
    }

    public void OpenTitle(){
        titlePanel.Execute();
    }

    public void CloseTitle(){
        titlePanel.Exit();
    }

    public void ReturnToTitle(){
        selectPanel.Exit();
    }

    public void SetDifficulty(int value){
        GameManager.instance.SettingDifficulty(value);
    }

    public void GameStart(){
        GameStartCoroutine().Start(this);
    }

    private IEnumerator GameStartCoroutine(){
        blackImage.gameObject.SetActive(true);
        Tween fadeTween = blackImage.DOFade(1.0f, 0.5f);
    
        yield return fadeTween.WaitForCompletion();

        SceneManager.LoadScene("Game");
    }
}
