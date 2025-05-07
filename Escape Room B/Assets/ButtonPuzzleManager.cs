using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleManager : MonoBehaviour
{
    public List<string> correctSequence = new List<string> { "Button1", "Button2", "Button3" };
    private List<string> playerInput = new List<string>();

    public GameObject monitorsToActivate;
    public List<ButtonInteract> allButtons;  // Assign all buttons in Inspector

    public void RegisterButtonPress(string buttonName)
    {
        playerInput.Add(buttonName);
        Debug.Log("Pressed: " + buttonName);

        if (playerInput.Count == correctSequence.Count)
        {
            if (IsCorrectSequence())
            {
                Debug.Log("Puzzle Complete! Monitors Activated!");
                FlashAllButtons(Color.green); // If correct it will flash green 

                if (monitorsToActivate != null)
                    monitorsToActivate.SetActive(true);
            }
            else
            {
                Debug.Log("Wrong Sequence! Try Again.");
                FlashAllButtons(Color.red); // If wrong it will flash red
                playerInput.Clear();
            }
        }
    }

    private bool IsCorrectSequence()
    {
        for (int i = 0; i < correctSequence.Count; i++)
        {
            if (playerInput[i] != correctSequence[i])
                return false;
        }
        return true;
    }

    private void FlashAllButtons(Color flashColor)
    {
        foreach (ButtonInteract btn in allButtons)
        {
            btn.FlashColor(flashColor);
        }
    }
}