using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleManager : MonoBehaviour
{
    // this is the order the player has to press the buttons in
    public List<string> correctSequence = new List<string> { "Button1", "Button2", "Button3", "Button4" };

    // keeps track of the buttons the player pressed so far
    private List<ButtonInteract> pressedButtons = new List<ButtonInteract>();

    // this is the object I put in to let me put in what monitor turns on when the puzzle is solved
    public GameObject monitorsToActivate;

    public void RegisterButtonPress(ButtonInteract button)
    {
        // stop if this button was already pressed
        if (pressedButtons.Contains(button)) return;

        // highlight the button as yellow when pressed
        button.SetColor(Color.yellow);

        // add it to the list of pressed buttons
        pressedButtons.Add(button);

        // once all 4 are pressed, check if it's the right order
        if (pressedButtons.Count == correctSequence.Count)
        {
            StartCoroutine(EvaluateSequence());
        }
    }

    private IEnumerator EvaluateSequence()
    {
        yield return new WaitForSeconds(0.3f); // small delay to let yellow flash first

        bool correct = true;

        // go through each button press and compare it to the correct order
        for (int i = 0; i < correctSequence.Count; i++)
        {
            if (pressedButtons[i].buttonName != correctSequence[i])
            {
                correct = false;
                break;
            }
        }

        // if it's correct, flash green, otherwise flash red
        Color resultColor = correct ? Color.green : Color.red;

        foreach (var button in pressedButtons)
        {
            button.SetColor(resultColor);
        }

        // turn on the monitor or clue if the puzzle was solved
        if (correct && monitorsToActivate != null)
        {
            monitorsToActivate.SetActive(true);
        }

        yield return new WaitForSeconds(0.5f); // wait before resetting everything

        // reset all buttons back to original color and clear the list
        foreach (var button in pressedButtons)
        {
            button.ResetColor();
        }

        pressedButtons.Clear();
    }
}