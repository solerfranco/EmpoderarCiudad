using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [HideInInspector]
    public PlayerController player;
    [HideInInspector]
    public EnergyManager energyManager;
    [HideInInspector]
    public PathMaker pathMaker;
    private int cleaners;
    public int Cleaners
    {
        set
        {
            cleaners = value;
            lampCounter.text = value.ToString();
        }
        get
        {
            return cleaners;
        }
    }

    public TextMeshProUGUI lampCounter;

    public Color lineColor;
    public Color lineColorError;

    public GameObject wonScreen;
    public GameObject loseScreen;

    private bool canShowMap;
    public GameObject map;
    public GameObject mapDialog;

    public GameObject panel;

    public bool pause;

    public Texture2D handCursor;
    public Texture2D grabCursor;

    public Animator animator;
    public RuntimeAnimatorController[] animators;

    public GameObject pauseMenu;

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

        pathMaker = FindObjectOfType<PathMaker>();
        energyManager = FindObjectOfType<EnergyManager>();
        player = FindObjectOfType<PlayerController>();

        animator.runtimeAnimatorController = animators[PlayerPrefs.GetInt("CharacterIndex",0)];
    }

    public void WonLevel()
    {
        wonScreen.SetActive(true);
        pause = true;
    }

    public void LoseLevel()
    {
        loseScreen.SetActive(true);
        pause = true;
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ShowMap()
    {
        if (!map.activeSelf)
        {
            panel.SetActive(false);
            mapDialog.SetActive(false);
            map.SetActive(true);
            canShowMap = true;
        }else
        {
            map.SetActive(false);
        }
    }

    public void CheckMap()
    {
        if (!canShowMap)
        {
            panel.SetActive(true);
            mapDialog.SetActive(true);
        }
        else
        {
            ShowMap();
        }
    }

    public void ReloadScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }

    }
}
