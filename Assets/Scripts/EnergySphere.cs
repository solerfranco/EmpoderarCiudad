using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class EnergySphere : MonoBehaviour
{
    public int energy = 8;
    public AudioSource clip;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        clip.Play();
        if (collision.transform.CompareTag("Player"))
        {
            clip.Play();
            //GameController.Instance.energyManager.Energy += energy;
            Destroy(gameObject,0.2f);
            
        }
    }
}
