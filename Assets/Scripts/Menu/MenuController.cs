using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject settings;

    private void Start()
    {
        audioMixer.SetFloat("masterVolume", Mathf.Log10(PlayerPrefs.GetFloat("masterVolume", 1)) * 20);
    }

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
