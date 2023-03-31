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
