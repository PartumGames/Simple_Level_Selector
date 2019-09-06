using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level_Info
{
    public string levelName;
    public Sprite levelIcon;
    public int levelSceneIndex;

    public bool hasPlayedBefor;
    public int bestScore;

    public bool isLevelLocked;

}
