using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject panel;
    public GameObject[] dialogs;

    private void Start()
    {
        if(dialogs.Length > 0)
        {
            panel.SetActive(true);
            dialogs[0].SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameController.Instance.pauseMenu.activeSelf && dialogs.Length > 0)
        {
            dialogs[0].SetActive(false);
            dialogs = dialogs.Skip(1).ToArray();
            if (dialogs.Length > 0)
            {
                dialogs[0].SetActive(true);
            }
            else
            {
                panel.SetActive(false);
                GameController.Instance.pause = false;
            }
        }
    }
}
