using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    public string buttonName; // the name of the button (used for checking the correct sequence)
    public ButtonPuzzleManager puzzleManager; // reference to the manager that handles the button puzzle

    private Renderer rend; // to access the material and change color
    private Color originalColor; // stores the original color so we can reset later

    void Start()
    {
        rend = GetComponent<Renderer>(); // get the renderer component on the button
        rend.material = new Material(rend.material); // create a copy of the material so changes don’t affect other buttons
        originalColor = rend.material.color; // save the starting color
    }

    private void OnMouseDown()
    {
        puzzleManager.RegisterButtonPress(this); // tell the puzzle manager this button was clicked
    }

    public void SetColor(Color color)
    {
        rend.material.color = color; // change the button’s color
    }

    public void ResetColor()
    {
        rend.material.color = originalColor; // set the color back to the original
    }
}