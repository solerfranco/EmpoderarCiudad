using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector Instance;

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
}
