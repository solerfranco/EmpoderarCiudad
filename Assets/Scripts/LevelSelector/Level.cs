using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int levelIndex;
    public GameObject thumbnail;

    public void SelectLevel()
    {
        LevelSelector.Instance.SelectedLevel = this;
    }

    public void ScaleUp()
    {
        LeanTween.scale(gameObject, Vector3.one * 1.1f, 0.3f).setEaseOutCirc();
        LeanTween.moveLocalX(thumbnail, 10, 1.5f).setLoopPingPong(-1);
    }

    public void ScaleDown()
    {
        LeanTween.scale(gameObject, Vector3.one * 1f, 0.3f).setEaseOutCirc();
        LeanTween.cancel(thumbnail);
        LeanTween.moveLocalX(thumbnail, 0, 0.25f);
    }
}
