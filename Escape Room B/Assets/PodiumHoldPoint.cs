using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumHoldPoint : MonoBehaviour
{
    public Transform placementPoint; // where the crystal will be placed
    public string expectedCrystalName; // the correct crystal’s name

    private GameObject placedCrystal; // keeps track of the crystal placed here

    public void PlaceCrystal(GameObject crystal)
    {
        placedCrystal = crystal;

        // snap crystal into place
        crystal.transform.SetParent(placementPoint);
        crystal.transform.localPosition = Vector3.zero;
        crystal.transform.localRotation = Quaternion.identity;
    }

    public bool IsCorrect()
    {
        // checks if the right crystal is placed here
        return placedCrystal != null && placedCrystal.name.Contains(expectedCrystalName);
    }
}