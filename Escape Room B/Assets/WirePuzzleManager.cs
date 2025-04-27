using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzleManager : MonoBehaviour
{
    public static WirePuzzleManager Instance;

    public WireNode selectedNode = null;
    public List<WireNode> nodes;
    public GameObject monitorsToActivate;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                WireNode node = hit.collider.GetComponent<WireNode>();

                if (node != null)
                {
                    OnNodeClicked(node);
                }
            }
        }
    }

    public void OnNodeClicked(WireNode node)
    {
        if (selectedNode == null)
        {
            selectedNode = node;
            selectedNode.Select();
        }
        else
        {
            if (selectedNode.colorName == node.colorName && selectedNode.isStart != node.isStart)
            {
                selectedNode.Connect();
                node.Connect();
            }
            else
            {
                selectedNode.Deselect();
                node.Deselect();
            }

            selectedNode = null;
        }

        CheckPuzzleComplete();
    }

    void CheckPuzzleComplete()
    {
        foreach (WireNode node in nodes)
        {
            if (!node.isConnected)
                return;
        }

        Debug.Log("Puzzle Complete! Monitors Activated!");

        if (monitorsToActivate != null)
            monitorsToActivate.SetActive(true);

        // You can also add closing the puzzle automatically here if you want
    }
}
