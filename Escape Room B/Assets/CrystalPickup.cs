using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : MonoBehaviour, IInteractable
{
    private bool isHeld = false;

    public void Interact()
    {
        if (!isHeld && CrystalManager.Instance.heldCrystal == null)
        {
            isHeld = true;
            CrystalManager.Instance.PickUpCrystal(this.gameObject);
        }
    }
}
