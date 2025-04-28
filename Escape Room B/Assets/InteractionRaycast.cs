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
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.red);
        HandleInteractionCheck();
        HandleInteractInput();
    }

    void HandleInteractionCheck()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red);  // BIG red line for testing

        if (Physics.Raycast(ray, out hit, rayDistance))   // Remove layer mask for now
        {
            currentInteractable = hit.collider.GetComponent<IInteractable>();

            if (currentInteractable != null)
            {
                Debug.Log("Looking at: " + hit.collider.name);
                if (interactHintUI != null)
                    interactHintUI.SetActive(true);
            }
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
