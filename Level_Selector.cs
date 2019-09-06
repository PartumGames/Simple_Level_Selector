using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//--need this
using UnityEngine.SceneManagement;//--need this

public class Level_Selector : MonoBehaviour
{
    public List<Level_Info> levels = new List<Level_Info>();
    private int index = 0;
    private Level_Info selectedLevel;

    public Image levelImage;
    public Text nameText;
    public Text bestTimeText;

    private Color normalColor;
    public Color disabledColor;


    private void Start()
    {
        normalColor = levelImage.color;
        selectedLevel = levels[index];
        PickLevel(0);
    }

    public void PickLevel(int _amnt)
    {
        index += _amnt;

        if (index > levels.Count - 1)
        {
            index = 0;
        }

        if (index < 0)
        {
            index = levels.Count - 1;
        }

        HandleData();
    }

    private void HandleData()
    {
        selectedLevel = levels[index];
        levelImage.sprite = selectedLevel.levelIcon;
        nameText.text = selectedLevel.levelName;

        if (selectedLevel.hasPlayedBefor)
        {
            bestTimeText.text = "Best: " + selectedLevel.bestScore.ToString();
        }
        else
        {
            bestTimeText.text = "";
        }

        if (selectedLevel.isLevelLocked)
        {
            levelImage.color = disabledColor;
        }
        else
        {
            levelImage.color = normalColor;
        }
    }

    public void SelectLevel()
    {
        if (!selectedLevel.isLevelLocked)
        {
            SceneManager.LoadScene(selectedLevel.levelSceneIndex);
        }
        else
        {
            Debug.Log("This level is locked");
        }
    }
}
