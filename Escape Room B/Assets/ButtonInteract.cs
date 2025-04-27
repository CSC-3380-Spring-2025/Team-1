using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    public string buttonName;
    public ButtonPuzzleManager puzzleManager;

    private Renderer rend;
    private Color originalColor;
    public Color pressedColor = Color.yellow;  // The color when clicked

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (puzzleManager != null)
        {
            puzzleManager.RegisterButtonPress(buttonName);
            Debug.Log(buttonName + " clicked!");

            rend.material.color = pressedColor;
            Invoke("ResetColor", 0.5f);
        }
    }

    void ResetColor()
    {
        rend.material.color = originalColor;
    }
}
