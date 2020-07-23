using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : DontDestroySingleton<GameManager>
{
    private Difficulty stageDifficulty;
    public Difficulty StageDifficulty => stageDifficulty;

    public void SettingDifficulty(int value){
        stageDifficulty = (Difficulty)value;
    }
}
