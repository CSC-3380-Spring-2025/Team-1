using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour
{
    private Camera mainCamera; // Camera reference
    private Vector2 lastPosition; // To avoid unnecessary raycasting every frame

    void Start()
    {
        // Find the main camera in the scene automatically
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Cast a ray from the camera through the center of the screen
        Vector3 rayPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(rayPosition);
        RaycastHit hit;

        // If the raycast hits something (UI element), simulate the click
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the raycast hit a UI element
            if (hit.collider != null)
            {
                // Use the EventSystem to trigger a click on the UI element
                PointerEventData pointerData = new PointerEventData(EventSystem.current);
                ExecuteEvents.Execute(hit.collider.gameObject, pointerData, ExecuteEvents.pointerClickHandler);
            }
        }
    }
}

