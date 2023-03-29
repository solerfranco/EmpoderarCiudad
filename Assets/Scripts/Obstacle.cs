using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnMouseDown()
    {
        if(FindObjectOfType<GameController>().cleaners > 0)
        {
            Destroy(gameObject);
        }
    }
}
