using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   public float interactionDistance = 3f; // How far the player can interact
    private Camera playerCamera;
    private Inventory inventory;

    void Start()
    {
        playerCamera = Camera.main;
        inventory = GetComponent<Inventory>(); // Get the Inventory component on the player
    }

    void Update()
    {
        CheckForInteractable();
    }

    void CheckForInteractable()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance))
        {
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                Debug.Log("Press 'E' to interact with " + hit.collider.name);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact(inventory);
                }
            }
        }
    }
}
