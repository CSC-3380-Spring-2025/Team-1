using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public GameObject timesUpPanel;

    private float timeLeft;
    private bool timerRunning = true;

    void Start()
{
    Time.timeScale = 1f;

    // Lock and hide the cursor
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;

    string scene = SceneManager.GetActiveScene().name;
    switch (scene)
    {
        case "EasyRoom":
            timeLeft = 300f;
            break;
        case "MedRoom":
            timeLeft = 480f;
            break;
        case "HardRoom":
            timeLeft = 600f;
            break;
        default:
            timeLeft = 300f;
            break;
    }

    if (timesUpPanel != null) timesUpPanel.SetActive(false);
}


    void Update()
    {
        if (!timerRunning) return;

        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Max(timeLeft, 0);

        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";

        if (timeLeft <= 0)
        {
            timerRunning = false;
            ShowTimesUpScreen();
        }
    }

    void ShowTimesUpScreen()
{
    timesUpPanel.SetActive(true);

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}


    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
