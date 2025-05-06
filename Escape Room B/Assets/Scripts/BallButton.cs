using UnityEngine;

// this makes sure that the gameobject has a renderer and a collider
[RequireComponent(typeof(Renderer), typeof(Collider))]
public class BallButton : MonoBehaviour
{
    
    public int index;

    
    public Color inactiveColor = Color.red;
    
    public Color activeColor   = Color.green;

    Renderer _renderer;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = new Material(_renderer.material); // instance
        _renderer.material.color = inactiveColor;
    }

    void OnMouseDown()
    {
        BallGridManager.Instance.HandleBallClick(index, this);
    }

    public void Activate()
    {
        _renderer.material.color = activeColor;
    }
}
