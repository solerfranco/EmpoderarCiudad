using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> nodes;
    public float speed;
    [HideInInspector]
    public bool moving;
    private GameObject targetNode;
    public AudioSource clip;

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
        nodes.Clear();
        targetNode = null;
        moving = false;
        clip.Pause();
    }
}
