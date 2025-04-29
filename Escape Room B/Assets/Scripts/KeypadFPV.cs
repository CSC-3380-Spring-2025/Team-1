using UnityEngine;
using NavKeypad;   // make sure this matches your namespace

public class KeypadFPV : MonoBehaviour
{
    private Camera cam;

    private void Awake() => cam = Camera.main;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // 1) Look for KeypadButtons (plural)
                if (hit.collider.TryGetComponent<KeypadButtons>(out var btn))
                {
                    // 2) Call PressButton() (singular)
                    btn.PressButton();
                }
            }
        }
    }
}
