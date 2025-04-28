using System.Collections;
using UnityEngine;

namespace NavKeypad
{
    public class KeypadButtons : MonoBehaviour
    {
        [Header("Value")]
        [SerializeField] private string value; // The value (number or symbol) this button represents.

        [Header("Animation Settings")]
        [SerializeField] private float buttonSpeed = 0.1f; // Speed of the button animation.
        [SerializeField] private float moveDistance = 0.0025f; // How far the button moves when pressed.

        [SerializeField] private Keypad keypad; // Reference to the Keypad component.

        private bool moving; // To prevent the button from being pressed multiple times while animating.

        // Called when the button is pressed.
        public void PressButton()
        {
            if (!moving)
            {
                keypad.AddInput(value); // Sends the value to the keypad.
                StartCoroutine(MoveSmooth()); // Starts the animation.
            }
        }

        // Smooth button press animation.
        private IEnumerator MoveSmooth()
        {
            moving = true;

            // Initial position of the button.
            Vector3 startPos = transform.localPosition;
            Vector3 endPos = transform.localPosition + new Vector3(0, 0, moveDistance); // Button pressed position.

            float elapsedTime = 0;
            while (elapsedTime < buttonSpeed)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(startPos, endPos, Mathf.Clamp01(elapsedTime / buttonSpeed)); // Moves the button smoothly.
                yield return null;
            }
            transform.localPosition = endPos; // Final pressed position.

            // Wait for a short duration before resetting the button.
            yield return new WaitForSeconds(0.1f);

            // Reset the button to its original position.
            startPos = transform.localPosition;
            endPos = transform.localPosition - new Vector3(0, 0, moveDistance);

            elapsedTime = 0;
            while (elapsedTime < buttonSpeed)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(startPos, endPos, Mathf.Clamp01(elapsedTime / buttonSpeed)); // Resets the button smoothly.
                yield return null;
            }
            transform.localPosition = endPos;

            moving = false; // Allow the button to be pressed again.
        }
    }
}
