using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subte : MonoBehaviour
{
    public Transform teleport;
    public bool receiving;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!receiving)
        {
            teleport.GetComponent<Subte>().receiving = true;
            collision.transform.position = teleport.position;
            FindObjectOfType<GameController>().ClearMovement();
        }
        if (receiving) receiving = false;
    }
}
