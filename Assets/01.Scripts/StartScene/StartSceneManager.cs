﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    private UIWidget titlePanel;

    [SerializeField]
    private UIWidget selectPanel;

    private void Start(){
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
}
