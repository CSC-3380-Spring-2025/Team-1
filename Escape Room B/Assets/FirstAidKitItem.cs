using UnityEngine;

public class FirstAidKitItem : MonoBehaviour, IInteractable
{
    public string itemName = "First Aid Kit";

    public void Interact() // Method is called when the player interacts with the first aid kit
    {
        HiddenInventory.Instance.AddItem(itemName);
        Debug.Log("Picked up: " + itemName);
        Destroy(gameObject);
    }
}