using UnityEngine;

public class NotebookItem : MonoBehaviour, IInteractable
{
    public string itemName = "Notebook";

    public void Interact() // Method is called when the player interacts with the notebook
    {
        HiddenInventory.Instance.AddItem(itemName);
        Debug.Log("Picked up: " + itemName);
        Destroy(gameObject);
    }
}