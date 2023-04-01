using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector Instance;
    public Animator selectedAnimator;

    public Image image;
    public TextMeshProUGUI description;
    
    private Character selectedCharacter;

    public Character SelectedCharacter
    {
        set
        {
            if (selectedCharacter != null) selectedCharacter.ScaleDown();
            selectedCharacter = value;
            image.sprite = value.image.sprite;
            description.text = value.description;
            selectedAnimator.runtimeAnimatorController = value.animator;
            value.ScaleUp();
        }
        get
        {
            return selectedCharacter;
        }
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

    private void Start()
    {
        SelectedCharacter = FindObjectOfType<Character>();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToPlay()
    {
        SceneManager.LoadScene(3);
    }
}
