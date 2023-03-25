using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public LayerMask pathNode;
    public LineRenderer line;
    public int lineIndex;
    public List<GameObject> selectedObjects;
    public GameObject player;
    public GameObject currentNode;
    public float speed;
    private bool move;
    public Slider energySlider;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
         
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, pathNode))
            {
                if (hit.collider != null && !selectedObjects.Contains(hit.collider.gameObject) && (lineIndex > 0 ? Vector3.Distance(selectedObjects[lineIndex - 1].transform.position, hit.transform.position) <= 15 : true) && (selectedObjects.Count <= 0 ? Vector3.Distance(hit.collider.transform.position, player.transform.position) < 5 : true))
                {
                    selectedObjects.Add(hit.collider.gameObject);
                    line.SetPosition(lineIndex, hit.collider.transform.position);
                    line.positionCount++;
                    lineIndex++;
                    line.SetPosition(lineIndex, hit.collider.transform.position);
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && selectedObjects.Count > 0)
        {
            move = false;
        }

        if (Input.GetMouseButtonUp(0) && selectedObjects.Count > 0)
        {
            move = true;
            lineIndex = 0;
            selectedObjects.RemoveAt(0);
            line.positionCount = 1;
            line.SetPosition(0, Vector3.zero);
        }

        if (selectedObjects.Count > 0 && move == true)
        {
            if(energySlider.value == 0)
            {
                currentNode = null;
                selectedObjects.RemoveRange(0, selectedObjects.Count);
                return;
            }
            if (currentNode != null)
            {
                if(Vector3.Distance(currentNode.transform.position, player.transform.position) > 0f)
                {
                    player.transform.position = Vector3.MoveTowards(player.transform.position, currentNode.transform.position, speed * Time.deltaTime);
                }
                else
                {
                    energySlider.value -= 1;
                    selectedObjects.RemoveAt(0);
                    if(selectedObjects.Count > 0)
                    {
                        currentNode = selectedObjects[0];
                    }
                }
            }
            else
            {
                currentNode = selectedObjects[0];
            }
        }
        else
        {
            currentNode = null;
        }

        if (Input.GetKeyDown(KeyCode.R)) energySlider.value = energySlider.maxValue;

    }
}
