using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMaker : MonoBehaviour
{
    public LayerMask nodeLayer;
    public LayerMask obstacleLayer;
    public LineRenderer line;
    private int lineIndex;
    [HideInInspector]
    public List<GameObject> nodes;
    [HideInInspector]
    public GameObject targetNode;
    [HideInInspector]
    public GameObject currentNode;
    private PlayerController player;
    private EnergyManager energyManager;

    private void Start()
    {
        energyManager = GameController.Instance.energyManager;
        player = GameController.Instance.player;
        SetCurrentNode();
    }

    private void Update()
    {
        if (GameController.Instance.player.moving) return;
        if (Input.GetMouseButton(0))
        {
            Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, Mathf.Infinity, nodeLayer);

            if(hit.collider != null)
            {
                Cursor.SetCursor(GameController.Instance.grabCursor, Vector2.one * 0.5f, CursorMode.Auto);
                if (nodes.Count == 0)
                {
                    if(currentNode == hit.transform.gameObject)
                    {
                        //Anadir el nodo inicial a la lista
                        nodes.Add(hit.collider.gameObject);
                        line.SetPosition(0, hit.collider.transform.position);
                    }
                    return;
                }
                if (!HasObstacle(hit) && !nodes.Contains(hit.transform.gameObject))
                {
                    if (Distance(nodes[nodes.Count - 1], hit) < 2f){
                        nodes.Add(hit.collider.gameObject);
                        lineIndex++;
                        line.positionCount++;
                        line.SetPosition(lineIndex, hit.collider.transform.position);
                        energyManager.Energy--;
                        if(energyManager.Energy < 0) SetLineColor(GameController.Instance.lineColorError);
                    }
                }
                if (nodes.Count > 1 && hit.transform == nodes[nodes.Count - 2].transform)
                {
                    lineIndex--;
                    line.positionCount--;
                    nodes.RemoveAt(nodes.Count-1);
                    energyManager.Energy++;
                    if (energyManager.Energy >= 0) SetLineColor(GameController.Instance.lineColor);
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && nodes.Count > 0)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            if (energyManager.Energy >= 0)
            {
                currentNode = nodes[nodes.Count - 1];
                GameController.Instance.player.Walk(new List<GameObject>(nodes));
            }
            else
            {
                energyManager.Energy += nodes.Count - 1;
                SetLineColor(GameController.Instance.lineColor);
                ClearPath();
            }
        }
    }

    private void SetCurrentNode()
    {
        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.zero, Mathf.Infinity, nodeLayer);
        currentNode = hit.transform.gameObject;
    }

    private void SetLineColor(Color color)
    {
        line.startColor = color;
        line.endColor = color;
    }

    public void ClearPath()
    {
        SetCurrentNode();
        lineIndex = 0;
        line.positionCount = 1;
        nodes.Clear();
    }

    private float Distance(GameObject obj1, RaycastHit2D obj2)
    {
        return Vector2.Distance(obj1.transform.position, obj2.transform.position);
    }

    private bool HasObstacle(RaycastHit2D hit)
    {
        RaycastHit2D checkWall = Physics2D.Raycast(Vector2.Lerp(nodes[nodes.Count - 1].transform.position, hit.transform.position, 0.5f), Vector2.zero, Mathf.Infinity, obstacleLayer);
        return checkWall.collider != null;
    }
}
