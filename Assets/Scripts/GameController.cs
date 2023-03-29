using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public LayerMask pathNode;
    public LayerMask wallLayer;
    public LineRenderer line;
    public int lineIndex;
    public List<GameObject> selectedObjects;
    public GameObject player;
    public GameObject currentNode;
    public float speed;
    private float initialSpeed;
    private bool move;
    public Image energySlider;
    public float maxEnergy;
    public TextMeshProUGUI textEnergy;
    private bool blocked;
    public int cleaners;

    private void Awake()
    {
        initialSpeed = speed;
    }

    void Update()
    {
        textEnergy.text = (energySlider.fillAmount * maxEnergy).ToString("F0");
        if (Input.GetMouseButton(0))
        {
            Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rayDirection = Vector2.zero; // set this to the direction you want the ray to be cast in

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity, pathNode);
            if (hit.collider != null && !selectedObjects.Contains(hit.collider.gameObject) && (lineIndex > 0 ? Vector2.Distance(selectedObjects[lineIndex - 1].transform.position, hit.transform.position) <= 1.5f : true) && (selectedObjects.Count <= 0 ? Vector2.Distance(hit.collider.transform.position, player.transform.position) <= 1 : true))
            {
                if (selectedObjects.Count > 0)
                {
                    RaycastHit2D checkWall = Physics2D.Raycast(Vector2.Lerp(selectedObjects[selectedObjects.Count-1].transform.position, hit.transform.position, 0.5f), rayDirection, Mathf.Infinity, wallLayer);
                    if(checkWall.collider != null)
                    {
                        return;
                    }
                }
                selectedObjects.Add(hit.collider.gameObject);
                line.SetPosition(lineIndex, hit.collider.transform.position);
                line.positionCount++;
                lineIndex++;
                line.SetPosition(lineIndex, hit.collider.transform.position);
            }
        }

        if (Input.GetMouseButtonDown(0) && selectedObjects.Count > 0 && move == true)
        {
            //speed = 20;
            move = false;
        }

        if (Input.GetMouseButtonUp(0) && blocked)
        {
            line.startColor = Color.green;
            line.endColor = Color.green;
            blocked = false;
            selectedObjects.Clear();
            lineIndex = 0;
            currentNode = null;
            line.positionCount = 1;
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
                speed = initialSpeed;
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
                speed = initialSpeed;
                currentNode = selectedObjects[0];
            }
        }
        else
        {
            speed = initialSpeed;
            currentNode = null;
        }

        if (Input.GetKeyDown(KeyCode.R)) energySlider.fillAmount = 1;

    }

    public void ClearMovement()
    {
        speed = initialSpeed;
        selectedObjects.Clear();
        currentNode = null;
        move = false;
    }
}
