using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
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
                keypadDisplayText.text = currentInput;
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

        yield return new WaitForSeconds(1f); // Wait before clearing input
        displayingResult = false;

        ClearInput();
    }

    private void AccessDenied()
    {
        keypadDisplayText.text = "Denied";
        onAccessDenied?.Invoke();
    }

    private void ClearInput()
    {
        currentInput = "";
        keypadDisplayText.text = currentInput;
    }

    private void AccessGranted()
    {
        keypadDisplayText.text = "Granted";
        onAccessGranted?.Invoke();
    }
}

