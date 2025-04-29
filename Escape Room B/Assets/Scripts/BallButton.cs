using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Collider))]
public class BallButton : MonoBehaviour
{
    [Tooltip("Index of this ball (0–11) in the grid, assign in Inspector)")]
    public int index;

    [Tooltip("Color when not yet activated")]
    public Color inactiveColor = Color.red;
    [Tooltip("Color when correctly activated")]
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

    /// <summary>Called by the manager when this ball is one of the correct eight.</summary>
    public void Activate()
    {
        _renderer.material.color = activeColor;
    }
}
