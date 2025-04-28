using System.Collections;
using UnityEngine;
using NavKeypad;

public class KeypadFPV : MonoBehaviour
{
    private Camera cam;

    private void Awake() => cam = Camera.main;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
                {
                    keypadButton.PressButton();
                }
            }
        }
    }
}
