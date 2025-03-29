using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();
    private Dictionary<string, GameObject> itemPrefabs = new Dictionary<string, GameObject>();

    public GameObject inventoryUI; 
    public Transform itemListParent; 
    public GameObject itemButtonPrefab; 

    public void AddItem(string itemName, GameObject itemPrefab)
    {
        if (!items.Contains(itemName))
        {
            items.Add(itemName);
            itemPrefabs[itemName] = itemPrefab;
            UpdateUI();
        }
    }

    public void RemoveItem(string itemName, Vector3 position)
    {
        if (!items.Contains(itemName)) return;

        items.Remove(itemName);
        Instantiate(itemPrefabs[itemName], position, Quaternion.identity);
        UpdateUI();
    }

    private void UpdateUI()
    {
        foreach (Transform child in itemListParent)
            Destroy(child.gameObject);

        foreach (string item in items)
            CreateItemButton(item);
    }

    private void CreateItemButton(string itemName)
    {
        GameObject newItemButton = Instantiate(itemButtonPrefab, itemListParent);
        newItemButton.GetComponentInChildren<Text>().text = itemName;
        newItemButton.GetComponent<Button>().onClick.AddListener(() => DropItem(itemName));
    }

    public void DropItem(string itemName)
    {
        RemoveItem(itemName, transform.position + transform.forward * 2);
    }

    public void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}
