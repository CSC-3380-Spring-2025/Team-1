using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRaycast : MonoBehaviour
{
    public float rayDistance = 5f; // how far the ray should check for interactables
    public LayerMask interactableLayer; // which layer to check for
    private IInteractable currentInteractable; // the object we're currently looking at

    public GameObject interactHintUI; // UI hint that shows "Press E"

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.red); // visualize the ray
        HandleInteractionCheck(); // check what we're looking at
        HandleInteractInput(); // check if we pressed E
    }

    void HandleInteractionCheck()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 50f, Color.red); // draw ray in scene view

        if (Physics.Raycast(ray, out hit, rayDistance)) // ray hits something
        {
            currentInteractable = hit.collider.GetComponent<IInteractable>(); // check if it’s interactable

            if (currentInteractable != null)
            {
                Debug.Log("Looking at: " + hit.collider.name);
                if (interactHintUI != null)
                    interactHintUI.SetActive(true); // show hint
            }
        }
        else
        {
            currentInteractable = null; // not looking at anything
            if (interactHintUI != null)
                interactHintUI.SetActive(false); // hide hint
        }
    }

    void HandleInteractInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact(); // press E to interact
        }
    }
}