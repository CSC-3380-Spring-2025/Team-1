using System.Collections;
using UnityEngine;
using NavKeypad;

public class KeypadButtons : MonoBehaviour
{
    [Header("Value")]
    //sets the buttons value. should only go 0-9 and enter
    [SerializeField] private string value;   

    [Header("Animation Settings")]
    [SerializeField] private float buttonSpeed = 0.1f;   
    [SerializeField] private float moveDistance = 0.0025f; 
    private bool moving; 

    //allows for the buttons to be pressed
    public void PressButton()
    {
        var kp = Keypad.Instance;
        if (kp == null)
        {
            Debug.LogError($"No keypad instance");
            return;
        }

        if (!moving)
        {
            Debug.Log($"Button Pressed: {value}");
            kp.AddInput(value);
            StartCoroutine(MoveSmooth());
        }
    }

    //moves the button in and back out
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
