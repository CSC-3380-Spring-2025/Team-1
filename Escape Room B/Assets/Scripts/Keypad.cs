using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
    public static Keypad Instance { get; private set; }

    [Header("Events")]
    //passcode on keypad is right
    [SerializeField] private UnityEvent onAccessGranted;
    //passcode on keypad is wrong
    [SerializeField] private UnityEvent onAccessDenied;

    [Header("Combination Code (9 Numbers Max) (For our game tho please keep under 6 numbers)")]
    [SerializeField] private int keypadCombo = 12345;

    [Header("Display and Colors")]
    [SerializeField] private TMP_Text keypadDisplayText;  
    [SerializeField] private Renderer panelMesh;

    //this is the string associated with the passcode as its being typed by the player
    private string currentInput;
    //prevents you from typing while the result is displaying
    private bool displayingResult = false;

    private void Awake()
    {
        Instance = this;
        ClearInput();
    }

    public void AddInput(string input)
    {
        if (displayingResult) return;

        if (input == "enter")
        {
            //when the player presses the enter button, this will check if the code is right or wrong
            CheckCombo();
        }
        else
        {
            if (currentInput.Length < 9)
            {
                currentInput += input;

                if (keypadDisplayText != null)
                {
                    keypadDisplayText.text = currentInput;
                }
                else
                {
                    Debug.LogError("keypadDisplayText is not assigned!");
                }
            }
        }
    }

    private void CheckCombo()
    {
        //compares input to the set combination
        bool granted = currentInput == keypadCombo.ToString();
        //this should fix the results not displaying
        if (!displayingResult)
        {
            StartCoroutine(DisplayResultRoutine(granted));
        }
    }
    // dispalays Granted or Denied based on the result
    private IEnumerator DisplayResultRoutine(bool granted)
    {
        displayingResult = true;

        if (granted)
            AccessGranted();
        else
            AccessDenied();

        yield return new WaitForSeconds(1f); 
        displayingResult = false;

        ClearInput();
    }
    //access denied display
    private void AccessDenied()
    {
        if (keypadDisplayText != null)
        {
            keypadDisplayText.text = "Denied";
        }
        onAccessDenied?.Invoke();
    }

    //access granted display
    private void AccessGranted()
    {
        if (keypadDisplayText != null)
        {
            keypadDisplayText.text = "Granted";
        }
        onAccessGranted?.Invoke();
    }

    //clears input for new use
    private void ClearInput()
    {
        currentInput = "";

        if (keypadDisplayText != null)
        {
            keypadDisplayText.text = currentInput;
        }
        else
        {
            Debug.LogError("keypadDisplayText is not assigned!");
        }
    }

    
}
