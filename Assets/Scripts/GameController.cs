using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    [HideInInspector]
    public PlayerController player;
    [HideInInspector]
    public EnergyManager energyManager;
    [HideInInspector]
    public PathMaker pathMaker;
    [HideInInspector]
    public int cleaners;

    public Color lineColor;
    public Color lineColorError;

    public GameObject wonScreen;

    private bool canShowMap;
    public GameObject map;
    public GameObject mapDialog;

    public GameObject panel;

    public bool pause;

    public Texture2D handCursor;
    public Texture2D grabCursor;

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
    }

    public void WonLevel()
    {
        wonScreen.SetActive(true);
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }

    }
}
