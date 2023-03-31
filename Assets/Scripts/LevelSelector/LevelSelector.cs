using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public static LevelSelector Instance;

    private Level selectedLevel;

    public Level SelectedLevel
    {
        set
        {
            if(selectedLevel != null) selectedLevel.ScaleDown();
            selectedLevel = value;
            value.ScaleUp();
        }
        get
        {
            return selectedLevel;
        }
    }

    public void LoadSelected()
    {
        if(selectedLevel != null) LoadLevel(selectedLevel.levelIndex);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}
