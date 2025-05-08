using UnityEngine;

public class ScaleInteract : MonoBehaviour, IInteractable
{
    public GameObject stickyNote4;
    public void Interact()
    {
        // The player needs a notebook, beaker, and first aid kit
        if (HiddenInventory.Instance.HasItem("Notebook") && HiddenInventory.Instance.HasItem("First Aid Kit") && HiddenInventory.Instance.HasItem("Beaker"))
        {
            // The final clue appears
            if (stickyNote4 != null)
            {
                stickyNote4.SetActive(true);
                Debug.Log("Success! A new clue appears.");
            }
        }
        else
        {
            Debug.Log("You do not have the correct items.");
        }
    }
}