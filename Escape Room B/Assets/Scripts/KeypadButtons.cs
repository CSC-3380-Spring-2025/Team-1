using System.Collections;
using UnityEngine;
using NavKeypad;

public class KeypadButtons : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private string value;         // The value (number or symbol) this button represents.

    [Header("Animation Settings")]
    [SerializeField] private float buttonSpeed = 0.1f;   // Speed of the button animation.
    [SerializeField] private float moveDistance = 0.0025f; // How far the button moves when pressed.

    private bool moving; // To prevent the button from being pressed multiple times while animating.

    // Called when the button is pressed.
    public void PressButton()
    {
        var kp = Keypad.Instance;
        if (kp == null)
        {
            Debug.LogError($"[KeypadButtons] No Keypad.Instance! Did you forget to put the Keypad script on a GameObject in the scene?");
            return;
        }

        if (!moving)
        {
            Debug.Log($"Button Pressed: {value}");
            kp.AddInput(value);
            StartCoroutine(MoveSmooth());
        }
    }

    // Smooth button press animation.
    private IEnumerator MoveSmooth()
    {
        moving = true;

        Vector3 startPos   = transform.localPosition;
        Vector3 pressedPos = startPos + Vector3.forward * moveDistance;

        float t = 0f;
        while (t < buttonSpeed)
        {
            t += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(startPos, pressedPos, t / buttonSpeed);
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);

        t = 0f;
        while (t < buttonSpeed)
        {
            t += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(pressedPos, startPos, t / buttonSpeed);
            yield return null;
        }

        moving = false;
    }
}
