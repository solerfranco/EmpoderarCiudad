using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject settings;

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenSettings()
    {
        settings.SetActive(true);
    }

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
