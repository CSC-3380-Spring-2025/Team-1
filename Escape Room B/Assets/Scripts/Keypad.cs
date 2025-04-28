using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
    // Singleton instance
    public static Keypad Instance { get; private set; }

    [Header("Events")]
    [SerializeField] private UnityEvent onAccessGranted;
    [SerializeField] private UnityEvent onAccessDenied;

    [Header("Combination Code (9 Numbers Max)")]
    [SerializeField] private int keypadCombo = 12345;

    [Header("Display and Colors")]
    [SerializeField] private TMP_Text keypadDisplayText;  
    [SerializeField] private Renderer panelMesh;

    private string currentInput;
    private bool displayingResult = false;

    private void Awake()
    {
        // Initialize singleton
        Instance = this;
        ClearInput();
    }

    public void AddInput(string input)
    {
        if (displayingResult) return;

        if (input == "enter")
        {
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
        bool granted = currentInput == keypadCombo.ToString();

        if (!displayingResult)
        {
            StartCoroutine(DisplayResultRoutine(granted));
        }
    }

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

    private void AccessDenied()
    {
        if (keypadDisplayText != null)
        {
            keypadDisplayText.text = "Denied";
        }
        onAccessDenied?.Invoke();
    }

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

    private void AccessGranted()
    {
        if (keypadDisplayText != null)
        {
            keypadDisplayText.text = "Granted";
        }
        onAccessGranted?.Invoke();
    }
}
