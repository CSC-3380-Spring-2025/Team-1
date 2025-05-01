using UnityEngine;

public class FirstAidKitItem : MonoBehaviour, IInteractable
{
    public string itemName = "First Aid Kit";

    public void Interact()
    {
        HiddenInventory.Instance.AddItem(itemName);
        Debug.Log("Picked up: " + itemName);
        Destroy(gameObject);
    }
}