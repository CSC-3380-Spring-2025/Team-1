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

        uniqueMaterial = new Material(rend.material);
        rend.material = uniqueMaterial;
    }

    public void Select()
    {
        rend.material.color = Color.yellow;  // Highlight color
    }

    public void Deselect()
    {
        rend.material.color = Color.white;   
    }

    public void Connect()
    {
        isConnected = true;

        rend.material.color = Color.green;
        rend.material.EnableKeyword("_EMISSION");
        rend.material.SetColor("_EmissionColor", Color.green * 2f);
    }
}
