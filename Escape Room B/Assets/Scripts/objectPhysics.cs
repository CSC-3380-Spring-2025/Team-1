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

        // Optional: Make sure gravity is enabled
        rb.useGravity = true;
    }

    // Remove Update unless you need custom forces
}
