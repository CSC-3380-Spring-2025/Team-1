using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePuzzleStarter : MonoBehaviour, IInteractable
{
    public GameObject wirePuzzleUI;         // Your puzzle UI or environment
    public Camera puzzleCamera;             // Optional: assign if using a special camera
    public PlayerController playerController;

    public void Interact()
    {
        Debug.Log("Starting Wire Puzzle!");

        wirePuzzleUI.SetActive(true);        // Show puzzle UI or objects

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerController != null)
            playerController.enabled = false;

        // If you're switching cameras, activate puzzleCamera here
        if (puzzleCamera != null)
            puzzleCamera.gameObject.SetActive(true);
    }
}