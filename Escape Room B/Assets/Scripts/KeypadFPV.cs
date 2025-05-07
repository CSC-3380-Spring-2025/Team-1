using UnityEngine;
using NavKeypad;  

//the code that came with the keypad asset pack called this keypad FPV so when i wrote our own version, i kept the same name, however it is diffent code. all KeypadFPV scripts from the asset pack have been removed from player
public class KeypadFPV : MonoBehaviour
{
    private Camera cam;

     private void Awake() 
    {
        // sets main camera
        cam = Camera.main;
    }

    
    private void Update()
    {
        //when left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<KeypadButtons>(out var btn))
                {
                    btn.PressButton();
                }
            }
        }
    }
}
