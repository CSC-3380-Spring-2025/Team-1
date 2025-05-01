using UnityEngine;

public class BeakerItem : MonoBehaviour, IInteractable
{
    public string itemName = "Beaker";

    public void Interact()
    {
        HiddenInventory.Instance.AddItem(itemName);
        Debug.Log("Picked up: " + itemName);
        Destroy(gameObject);
    }
}