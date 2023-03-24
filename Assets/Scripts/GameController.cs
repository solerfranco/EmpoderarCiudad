using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public LayerMask pathNode;
    public LineRenderer line;
    public int lineIndex;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, pathNode))
            {
                if (hit.collider != null)
                {
                    line.SetPosition(lineIndex, hit.collider.transform.position);
                    line.positionCount++;
                    lineIndex++;
                    line.SetPosition(lineIndex, hit.collider.transform.position);
                    Debug.Log("Objeto clickeado: " + hit.collider.gameObject.name);
                }
            }
        }
    }
}
