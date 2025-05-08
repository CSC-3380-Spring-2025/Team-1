using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on " + gameObject.name);
        }
        rb.useGravity = true;
    }
}
