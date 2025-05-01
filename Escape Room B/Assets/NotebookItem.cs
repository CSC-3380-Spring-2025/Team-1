using UnityEngine;

public class NotebookItem : MonoBehaviour, IInteractable
{
    public string itemName = "Notebook";

    public void Interact()
    {
        HiddenInventory.Instance.AddItem(itemName);
        Debug.Log("Picked up: " + itemName);
        Destroy(gameObject);
    }
}