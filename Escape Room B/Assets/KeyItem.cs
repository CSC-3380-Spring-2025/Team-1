using UnityEngine;

public class KeyItem : MonoBehaviour, IInteractable
{
    public string itemName = "LockerKey";

    public void Interact()
    {
        HiddenInventory.Instance.AddItem(itemName);
        Debug.Log("Picked up: " + itemName);
        Destroy(gameObject);
    }
}