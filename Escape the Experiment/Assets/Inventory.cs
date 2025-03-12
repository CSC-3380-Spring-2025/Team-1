using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>(); // Store item names in a list

    public void AddItem(string itemName)
    {
        items.Add(itemName);
        Debug.Log("Added to Inventory: " + itemName);
    }

    public bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }
}
