using UnityEngine;

public class CreditsRoll : MonoBehaviour
{
    public float scrollSpeed = 20f;

    void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }
}
