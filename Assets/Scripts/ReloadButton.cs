using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadButton : MonoBehaviour
{
    private UnityEngine.UI.Button button;

    private void Start()
    {
        button.onClick.AddListener(GameController.Instance.ReloadScreen);
    }
}
