using UnityEngine;

public class KeyItem : MonoBehaviour, IInteractable
{
    public string itemName = "LockerKey";

    public void Interact() // Method is called when the player interacts with the key
    {
        HiddenInventory.Instance.AddItem(itemName);
        Debug.Log("Picked up: " + itemName);
        Destroy(gameObject);
    }
}