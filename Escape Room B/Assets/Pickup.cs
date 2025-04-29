using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
   public static Pickup Instance;

    public Transform holdPoint;
    private GameObject heldObject;

    void Awake()
    {
        Instance = this;
    }

    public void TryPickupOrDrop(GameObject clickedObject)
    {
        if (heldObject == null)
        {
            TryPickup(clickedObject);
        }
        else
        {
            TryDrop(clickedObject);
        }
    }

    void TryPickup(GameObject obj)
    {
        if (!obj.CompareTag("Crystal")) return; 

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        obj.transform.SetParent(holdPoint);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        heldObject = obj;
    }

    void TryDrop(GameObject obj)
    {
        if (!obj.CompareTag("Podium")) return;

        PodiumHoldPoint podium = obj.GetComponent<PodiumHoldPoint>();
        if (podium == null)
        {
            Debug.LogWarning("Podium has no PodiumHoldPoint script!");
            return;
        }

        podium.PlaceCrystal(heldObject);

        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = true; // so it doesn't fall

        heldObject = null;

        // After placing, check if puzzle is solved
        MatchPuzzleManager.Instance.CheckPuzzle();
    }
}
