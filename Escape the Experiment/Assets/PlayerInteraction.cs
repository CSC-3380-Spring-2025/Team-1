using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3f; 
    private Camera playerCamera;
    private Inventory inventory;

    void Start()
    {
        playerCamera = Camera.main;
        inventory = GetComponent<Inventory>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TryInteract();

        if (Input.GetKeyDown(KeyCode.I))
            inventory.ToggleInventory();
    }

    private void TryInteract()
    {
        if (!Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, interactionDistance))
            return;

        InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
        if (interactable != null)
            interactable.Interact(inventory);
    }
}