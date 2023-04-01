using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //private void OnMouseEnter()
    //{
    //    Cursor.SetCursor(GameController.Instance.handCursor, Vector2.one * 0.5f, CursorMode.Auto);
    //}

    //private void OnMouseExit()
    //{
    //    if (!Input.GetMouseButton(0))
    //    {
    //        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    //    }
    //}

    private void OnMouseDown()
    {
        if(GameController.Instance.cleaners > 0)
        {
            GameController.Instance.cleaners--;
            Destroy(gameObject);
        }
    }
}
