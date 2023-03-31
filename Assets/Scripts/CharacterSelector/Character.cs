using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public Image image;
    public string description;

    private void Awake()
    {
        image = transform.GetChild(0).GetComponent<Image>();
    }

    public void SelectCharacter()
    {
        CharacterSelector.Instance.SelectedCharacter = this;
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
