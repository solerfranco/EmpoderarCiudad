using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> nodes;
    public float speed;
    public bool moving;
    private GameObject targetNode;

    public void Walk(List<GameObject> nodeList)
    {
        moving = true;
        nodes = nodeList;
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
        nodes.Clear();
        targetNode = null;
        moving = false;
    }
}
