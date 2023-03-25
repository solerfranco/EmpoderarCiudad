using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySphere : MonoBehaviour
{
    public Image energySlider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            energySlider.fillAmount = 1;
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Respawn()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(10);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
