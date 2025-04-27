using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireNode : MonoBehaviour
{
  public string colorName;
    public bool isStart;
    public bool isConnected = false;

    private Material uniqueMaterial;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // Create a unique instance of the material
        uniqueMaterial = new Material(rend.material);
        rend.material = uniqueMaterial;
    }

    public void Select()
    {
        rend.material.color = Color.yellow;  // Highlight color
    }

    public void Deselect()
    {
        rend.material.color = Color.white;   // Or set this back to your default color
    }

    public void Connect()
    {
        isConnected = true;
        rend.material.color = Color.green;   // Connected color
    }
}
