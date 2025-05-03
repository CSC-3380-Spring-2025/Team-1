using System.Collections.Generic;
using UnityEngine;

public class HiddenInventory : MonoBehaviour
{
    public static HiddenInventory Instance;

    private HashSet<string> items = new HashSet<string>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

//add item to inventory
    public void AddItem(string itemName)
    {
        items.Add(itemName);
        Debug.Log("Added to your inventory: " + itemName);
    }

//is there an item in the inventory?
    public bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }

//remove item from inventory
    public void RemoveItem(string itemName)
    {
        if (items.Contains(itemName))
        {
            items.Remove(itemName);
            Debug.Log("Removed from your inventory: " + itemName);
        }
    }
}