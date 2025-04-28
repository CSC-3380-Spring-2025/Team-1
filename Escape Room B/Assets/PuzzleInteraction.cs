using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInteraction : MonoBehaviour
{
    public GameObject wirePuzzleUI; // Assign your Wire Puzzle UI

    private bool inPuzzle = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!inPuzzle)
            {
                OpenPuzzle();
            }
            else
            {
                ClosePuzzle();
            }
        }
    }

    void OpenPuzzle()
    {
        inPuzzle = true;
        wirePuzzleUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // You might also want to disable player movement here
    }

    void ClosePuzzle()
    {
        inPuzzle = false;
        wirePuzzleUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Re-enable player movement here
    }
}
