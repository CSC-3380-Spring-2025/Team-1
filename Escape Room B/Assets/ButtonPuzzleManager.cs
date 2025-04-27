using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleManager : MonoBehaviour
{
      public List<string> correctSequence = new List<string> { "Button1", "Button2", "Button3" };
    private List<string> playerInput = new List<string>();

    public GameObject monitorsToActivate;   // This is your ScreenManager GameObject

    public void RegisterButtonPress(string buttonName)
    {
        playerInput.Add(buttonName);
        Debug.Log("Pressed: " + buttonName);

        if (playerInput.Count == correctSequence.Count)
        {
            if (IsCorrectSequence())
            {
                Debug.Log("Puzzle Complete! Monitors Activated!");

                if (monitorsToActivate != null)
                    monitorsToActivate.SetActive(true);   // Show ScreenManager
            }
            else
            {
                Debug.Log("Wrong Sequence! Try Again.");
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
}
