using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

//starts with the panel turned off
    void Start()
    {
        pauseMenuUI.SetActive(false); 
    }

//panel pulls up when esc button is clicked
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) 
                Resume();
            else 
                Pause();
        }
    }

    public void Resume()
{
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    isPaused = false;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
}

//locks cursor
public void Pause()
{
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    isPaused = true;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}

//returns to mainmenu
public void ReturnGame()
{
    Time.timeScale = 1f;
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    SceneManager.LoadScene("MainMenu");
}

}
