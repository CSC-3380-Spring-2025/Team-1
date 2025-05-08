using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public static Pickup Instance; 

    public Transform holdPoint; // where the crystal appears in the player's hand
    private GameObject heldObject; // the object we're currently holding

    void Awake()
    {
        Instance = this;
    }

    public void TryPickupOrDrop(GameObject clickedObject)
    {
        if (heldObject == null)
        {
            TryPickup(clickedObject); // try picking up a crystal
        }
        else
        {
            TryDrop(clickedObject); // try placing it on a podium
        }
    }

    void TryPickup(GameObject obj)
    {
        if (!obj.CompareTag("Crystal")) return; // only pick up if it's tagged as a crystal

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true; // stop it from moving
        }

        obj.transform.SetParent(holdPoint); // attach to hand
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        heldObject = obj; // remember what we’re holding
    }

    void TryDrop(GameObject obj)
    {
        if (!obj.CompareTag("Podium")) return; // only drop onto podiums

        PodiumHoldPoint podium = obj.GetComponent<PodiumHoldPoint>();
        if (podium == null)
        {
            Debug.LogWarning("Podium has no PodiumHoldPoint script!");
            return;
        }

        podium.PlaceCrystal(heldObject); // put the crystal on the podium

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = true; // keep it still

        heldObject = null; // we're no longer holding anything

        // check if this completed the puzzle
        MatchPuzzleManager.Instance.CheckPuzzle();
    }
}