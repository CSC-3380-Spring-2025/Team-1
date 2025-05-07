using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public Button replayButton;

    void Start()
    {
        // Make the cursor visible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Add listener for the replay game button
        replayButton.onClick.AddListener(ReturnToMainMenu);
    }

    // Just returns to main menu after game is finished
    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
