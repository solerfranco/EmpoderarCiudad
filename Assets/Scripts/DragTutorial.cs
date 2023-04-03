using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTutorial : MonoBehaviour
{
    public GameObject mouse;
    public Vector2 initialPosition;
    public GameObject line1;
    public GameObject line2;

    void Start()
    {
        Animation();
    }

    void Animation()
    {
        LeanTween.moveLocalY(mouse, 5.6f, 1.5f).setEaseInQuad().setOnComplete(() =>
        {
            line1.SetActive(true);
            LeanTween.moveLocalX(mouse, -22, 1.5f).setEaseInQuad().setOnComplete(() =>
            {
                line2.SetActive(true);
                Invoke(nameof(Clear), 0.5f);
                Invoke(nameof(Animation), 1.5f);
            });
        });
    }

    void Clear()
    {
        mouse.transform.localPosition = initialPosition;
        line1.SetActive(false);
        line2.SetActive(false);
    }
}
