using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumInteract : MonoBehaviour, IInteractable
{
   public string correctCrystalName;
    public Transform placementPoint;
    private GameObject placedCrystal = null;

    public void Interact()
    {
        if (CrystalManager.Instance.heldCrystal != null && placedCrystal == null)
        {
            GameObject crystal = CrystalManager.Instance.heldCrystal;
            placedCrystal = crystal;

            // Place crystal on podium
            crystal.transform.SetParent(null);
            crystal.transform.position = placementPoint.position;
            crystal.transform.rotation = placementPoint.rotation;

            CrystalManager.Instance.heldCrystal = null;

            Debug.Log("Placed " + crystal.name + " on " + gameObject.name);

            // Check if placed correctly
            CrystalManager.Instance.CheckPuzzleCompletion();
        }
    }

    public bool IsCorrect()
    {
        return placedCrystal != null && placedCrystal.name == correctCrystalName;
    }
}
