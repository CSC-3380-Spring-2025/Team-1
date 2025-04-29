using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    public static CrystalManager Instance;

    public Transform holdPoint;           
    public GameObject heldCrystal = null;
    public PodiumInteract[] podiums;
    public GameObject keypadNumbers;      

    void Awake()
    {
        Instance = this;
    }

    public void PickUpCrystal(GameObject crystal)
    {
        heldCrystal = crystal;
        crystal.transform.SetParent(holdPoint);
        crystal.transform.localPosition = Vector3.zero;
        crystal.transform.localRotation = Quaternion.identity;

        Rigidbody rb = crystal.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = true;

        Debug.Log("Picked up: " + crystal.name);
    }

    public void CheckPuzzleCompletion()
    {
        foreach (PodiumInteract podium in podiums)
        {
            if (!podium.IsCorrect())
                return;
        }

        Debug.Log("All crystals placed correctly! Keypad activated.");
        keypadNumbers.SetActive(true);
    }
}
