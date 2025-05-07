using UnityEngine;
using UnityEngine.EventSystems;

public class Clicker : MonoBehaviour
{
    private Camera mainCamera; 
    private Vector2 lastPosition; 
    //sets main camera as our camera
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        //Makes the clicker button in the center of the screen (was supposed to be a crosshair like in minecraft but i was out voted)
        Vector3 rayPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = mainCamera.ScreenPointToRay(rayPosition);
        RaycastHit hit;
        //allows objects to be clickable through the dot in the middle of the screen
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                PointerEventData pointerData = new PointerEventData(EventSystem.current);
                ExecuteEvents.Execute(hit.collider.gameObject, pointerData, ExecuteEvents.pointerClickHandler);
            }
        }
    }
}

