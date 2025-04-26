using UnityEngine;

public class LockerInteract : MonoBehaviour, IInteractable
{
    public string requiredItem = "LockerKey"; // locker key required to open
    public GameObject lockerDoor; 
    private bool isOpen = false;

    public void Interact()
    {
        if (isOpen)
            return;

        if (HiddenInventory.Instance.HasItem(requiredItem))
        {
            OpenLocker();
            HiddenInventory.Instance.RemoveItem(requiredItem); //removes key 
        }
        else
        {
            Debug.Log("The locker is locked. You need a key.");
        }
    }

    private void OpenLocker()
    {
        isOpen = true;

        if (lockerDoor != null)
            lockerDoor.transform.Rotate(0, -90, 0); //locker door opens

        Debug.Log("Puzzle 1 Complete.");
    }
}