using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleManager : MonoBehaviour
{
    public List<string> correctSequence = new List<string> { "Button1", "Button2", "Button3", "Button4" };
    private List<ButtonInteract> pressedButtons = new List<ButtonInteract>();

    public GameObject monitorsToActivate;

    public void RegisterButtonPress(ButtonInteract button)
    {
        // Only allow one press per button
        if (pressedButtons.Contains(button)) return;

        button.SetColor(Color.yellow);
        pressedButtons.Add(button);

        if (pressedButtons.Count == correctSequence.Count)
        {
            StartCoroutine(EvaluateSequence());
        }
    }

    private IEnumerator EvaluateSequence()
    {
        yield return new WaitForSeconds(0.3f); // slight delay for clarity

        bool correct = true;

        for (int i = 0; i < correctSequence.Count; i++)
        {
            if (pressedButtons[i].buttonName != correctSequence[i])
            {
                correct = false;
                break;
            }
        }

        Color resultColor = correct ? Color.green : Color.red;

        foreach (var button in pressedButtons)
        {
            button.SetColor(resultColor);
        }

        if (correct && monitorsToActivate != null)
        {
            monitorsToActivate.SetActive(true);
        }

        yield return new WaitForSeconds(0.5f);

        foreach (var button in pressedButtons)
        {
            button.ResetColor();
        }

        pressedButtons.Clear();
    }
}