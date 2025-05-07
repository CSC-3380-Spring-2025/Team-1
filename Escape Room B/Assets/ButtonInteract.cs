using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    public string buttonName;
    public ButtonPuzzleManager puzzleManager;

    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = new Material(rend.material); // ensure unique material instance
        originalColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        puzzleManager.RegisterButtonPress(this);
    }

    public void SetColor(Color color)
    {
        rend.material.color = color;
    }

    public void ResetColor()
    {
        rend.material.color = originalColor;
    }
}