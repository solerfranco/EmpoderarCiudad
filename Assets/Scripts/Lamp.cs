using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Lamp : MonoBehaviour
{
    public AudioSource clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            clip.Play();
            FindObjectOfType<GameController>().Cleaners++;
            Destroy(gameObject,0.4f);
        }
    }
}
