using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string itemName; // Name of the object
    public bool isPickupable = false; // If true, the player can pick it up

    public void Interact(Inventory inventory)
    {
        if (isPickupable)
        {
            PickUp(inventory);
        }
        else
        {
            Debug.Log("Interacted with " + gameObject.name);
        }
    }

    void PickUp(Inventory inventory)
    {
        inventory.AddItem(itemName);
        Debug.Log("Picked up " + itemName);
        Destroy(gameObject); // Remove the object from the scene
    }
}
