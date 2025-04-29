using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumHoldPoint : MonoBehaviour
{
    public Transform placementPoint;  
    public string expectedCrystalName;  

    private GameObject placedCrystal;

    public void PlaceCrystal(GameObject crystal)
    {
        placedCrystal = crystal;
        crystal.transform.SetParent(placementPoint);
        crystal.transform.localPosition = Vector3.zero;
        crystal.transform.localRotation = Quaternion.identity;
    }

    public bool IsCorrect()
    {
        return placedCrystal != null && placedCrystal.name.Contains(expectedCrystalName);
    }
}
