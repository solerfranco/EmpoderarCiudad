using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public Image image;
    public string description;
    public int index;
    public RuntimeAnimatorController animator;

    private void Awake()
    {
        image = transform.GetChild(0).GetComponent<Image>();
    }

    public void SelectCharacter()
    {
        CharacterSelector.Instance.SelectedCharacter = this;
        PlayerPrefs.SetInt("CharacterIndex", index);
    }

    public void ScaleUp()
    {
        LeanTween.scale(gameObject, Vector3.one * 0.94f, 0.3f).setEaseOutCirc();
    }

    public void ScaleDown()
    {
        LeanTween.scale(gameObject, Vector3.one * 1f, 0.3f).setEaseOutCirc();
    }
}
