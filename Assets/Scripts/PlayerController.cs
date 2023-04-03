using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> nodes;
    public float speed;
    [HideInInspector]
    public bool moving;
    private GameObject targetNode;
    public AudioSource clip;

    public Sprite[] characters;

    public void Walk(List<GameObject> nodeList)
    {
        moving = true;
        nodes = nodeList;
        clip.Play();
    }

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

    private void Start()
    {
        GetSprite();
    }

    private void GetSprite()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = characters[PlayerPrefs.GetInt("CharacterIndex", 0)];
    }

    private void Update()
    {
        if (nodes.Count > 0)
        {
            if (targetNode == null) targetNode = nodes[0];
            if(Vector2.Distance(transform.position, targetNode.transform.position) > 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetNode.transform.position, speed * Time.deltaTime);
            }
            else if(nodes.Count > 1)
            {
                nodes.RemoveAt(0);
                targetNode = nodes[0];
            }else
            {
                ClearPath();
                GameController.Instance.pathMaker.ClearPath();
            }
        }
    }

    public void ClearPath()
    {
        if (GameController.Instance.energyManager.Energy <= 0) GameController.Instance.LoseLevel();
        nodes.Clear();
        targetNode = null;
        moving = false;
        clip.Pause();
    }
}
