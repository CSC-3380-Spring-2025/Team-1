using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string itemName;
    public bool isPickupable;
    public GameObject itemPrefab;

    public void Interact(Inventory inventory)
    {
        if (isPickupable)
            PickUp(inventory);
        else
            Debug.Log("Interacted with " + gameObject.name);
    }

    private void PickUp(Inventory inventory)
    {
        inventory.AddItem(itemName, itemPrefab);
        Destroy(gameObject);
    }
}