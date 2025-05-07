using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public Button replayButton;

    void Start()
    {
        replayButton.onClick.AddListener(ReturnToMainMenu);
    }

//just returns to main menu after game is finished
    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
