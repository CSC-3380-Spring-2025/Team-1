using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzleManager : MonoBehaviour
{
    public static WirePuzzleManager Instance;

    public WireNode selectedNode = null;
    public List<WireNode> nodes;
    public GameObject monitorsToActivate;
    public GameObject wireConnectionPrefab;  
    public Color connectedWireColor = Color.green;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))  
            {
                Debug.Log("Hit: " + hit.collider.name); 

                WireNode node = hit.collider.GetComponent<WireNode>();

                if (node != null)
                {
                    OnNodeClicked(node);
                }
            }
            else
            {
                Debug.Log("Raycast missed!");
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

                // Create wire connection visual
                GameObject wireObj = new GameObject("WireConnection");

                // Parent the wire object under a container for organization
                GameObject container = GameObject.Find("WireConnections");
                if (container != null)
                {
                    wireObj.transform.parent = container.transform;
                }

                // Add WireConnection script and draw the wire
                WireConnection connection = wireObj.AddComponent<WireConnection>();
                connection.DrawConnection(selectedNode.transform.position, node.transform.position, connectedWireColor);

                // Add glow effect (optional)
                connection.SetGlow(connectedWireColor);
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

        FindObjectOfType<PlayerController>().enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
