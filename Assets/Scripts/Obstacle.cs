using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Obstacle : MonoBehaviour
{
    public GameObject streetLight;

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
    public AudioSource clip;

    private void OnMouseDown()
    {
        if(GameController.Instance.Cleaners > 0)
        {
            clip.Play();
            GameController.Instance.Cleaners--;
            Destroy(gameObject, 0.5f);
            Instantiate(streetLight, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }
    }
}
