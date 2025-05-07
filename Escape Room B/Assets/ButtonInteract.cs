using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    public string buttonName;
    public ButtonPuzzleManager puzzleManager;

    private Renderer rend;
    private Color originalColor;
    public Color pressedColor = Color.yellow;  // When the button is clicked it should turn yellow

    void Start()
    {
        rend = GetComponent<Renderer>();

        rend.material = new Material(rend.material);
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

    public void FlashColor(Color flashColor)
    {
        rend.material.color = flashColor;
        CancelInvoke("ResetColor");
        Invoke("ResetColor", 0.5f);

        Debug.Log(gameObject.name + " flashing color: " + flashColor); 
    }

    void ResetColor()
    {
        rend.material.color = originalColor;
    }
}