using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
      void OnMouseDown()
    {
        if (Pickup.Instance != null)
        {
            Pickup.Instance.TryPickupOrDrop(this.gameObject);
        }
    }
}
