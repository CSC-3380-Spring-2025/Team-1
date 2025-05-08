using UnityEngine;

public class BeakerItem : MonoBehaviour, IInteractable
{
    public string itemName = "Beaker";

    public void Interact() // Method is called when the player interacts with the beaker
    {
        HiddenInventory.Instance.AddItem(itemName);
        Debug.Log("Picked up: " + itemName);
        Destroy(gameObject);
    }
}