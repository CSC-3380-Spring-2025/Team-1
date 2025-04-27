using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzleStarter : MonoBehaviour, IInteractable
{
     public GameObject wirePuzzleUI;

    public void Interact()
    {
        Debug.Log("Starting Wire Puzzle!");
        wirePuzzleUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Disable player movement here if needed
    }
}