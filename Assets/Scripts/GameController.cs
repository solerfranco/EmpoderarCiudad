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
    public Image energySlider;
    public float maxEnergy;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rayDirection = Vector2.zero; // set this to the direction you want the ray to be cast in

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity, pathNode);
            if (hit.collider != null && !selectedObjects.Contains(hit.collider.gameObject) && (lineIndex > 0 ? Vector2.Distance(selectedObjects[lineIndex - 1].transform.position, hit.transform.position) <= 1.5f : true) && (selectedObjects.Count <= 0 ? Vector2.Distance(hit.collider.transform.position, player.transform.position) <= 1 : true))
            {
                selectedObjects.Add(hit.collider.gameObject);
                line.SetPosition(lineIndex, hit.collider.transform.position);
                line.positionCount++;
                lineIndex++;
                line.SetPosition(lineIndex, hit.collider.transform.position);
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
            line.SetPosition(0, Vector2.zero);
        }

        if (selectedObjects.Count > 0 && move == true)
        {
            if(energySlider.fillAmount == 0)
            {
                currentNode = null;
                selectedObjects.RemoveRange(0, selectedObjects.Count);
                return;
            }
            if (currentNode != null)
            {
                if(Vector3.Distance(currentNode.transform.position, player.transform.position) > 0f)
                {
                    player.transform.position = Vector2.MoveTowards(player.transform.position, currentNode.transform.position, speed * Time.deltaTime);
                }
                else
                {
                    energySlider.fillAmount -= 1 / maxEnergy;
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

        if (Input.GetKeyDown(KeyCode.R)) energySlider.fillAmount = 1;

    }
}
