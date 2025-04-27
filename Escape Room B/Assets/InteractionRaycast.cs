using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRaycast : MonoBehaviour
{
  public float rayDistance = 5f;
    public LayerMask interactableLayer;
    private IInteractable currentInteractable;

    // Optional: Show UI hint (like "Press E to Interact")
    public GameObject interactHintUI;

    void Update()
    {
        HandleInteractionCheck();
        HandleInteractInput();
    }

    void HandleInteractionCheck()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            currentInteractable = hit.collider.GetComponent<IInteractable>();

            if (currentInteractable != null && interactHintUI != null)
                interactHintUI.SetActive(true);
        }
        else
        {
            currentInteractable = null;

            if (interactHintUI != null)
                interactHintUI.SetActive(false);
        }
    }

    void HandleInteractInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
}
