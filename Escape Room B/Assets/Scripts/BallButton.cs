using UnityEngine;

// this makes sure that the gameobject has a renderer and a collider
[RequireComponent(typeof(Renderer), typeof(Collider))]
public class BallButton : MonoBehaviour
{
    //this will allow us to identify each ball in the grid
    public int index;

    //will change the color of the ball to green when activated/will stay red if not activated
    public Color inactiveColor = Color.red;
    
    public Color activeColor   = Color.green;

    Renderer _renderer;
    //Awake will set the color to red by defaukt and change only the ball that is clicked
    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material = new Material(_renderer.material);
        _renderer.material.color = inactiveColor;
    }
    //OnMouseDown and Activate actually change the colors when clicked
    void OnMouseDown()
    {
        BallGridManager.Instance.HandleBallClick(index, this);
    }

    public void Activate()
    {
        _renderer.material.color = activeColor;
    }
}
