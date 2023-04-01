using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySphere : MonoBehaviour
{
    public int energy = 8;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //GameController.Instance.energyManager.Energy += energy;
            Destroy(gameObject);
        }
    }
}
