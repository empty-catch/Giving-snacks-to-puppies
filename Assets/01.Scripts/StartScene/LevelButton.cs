using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private GameObject selectObject;

    public static LevelButton SelectButton;

    private void Awake(){
        if(gameObject.name.Equals("Default")){
            LevelButton.SelectButton = this;
            OpenObject();
        }
    }

    public void OpenObject(){
        selectObject.SetActive(true);
    }

    public void CloseObject(){
        selectObject.SetActive(false);
    }

    public void SetButton(){
        LevelButton.SelectButton?.CloseObject();
        this.OpenObject();

        LevelButton.SelectButton = this;
    }
}
