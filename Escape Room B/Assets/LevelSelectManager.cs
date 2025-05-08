using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public Button easyButton;
    public Button medButton;
    public Button hardButton;

    void Start()
    {
        // makes the cursor visible and unlocked in the Level Select scene
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

       
        easyButton.interactable = true;
        medButton.interactable = true;
        hardButton.interactable = true;
    }

    public void LoadEasyRoom()  
    { 
        LockCursor(); 
        LoadScene("EasyRoom"); 
    }

    public void LoadMedRoom()   
    { 
        LockCursor(); 
        LoadScene("MedRoom"); 
    }

    public void LoadHardRoom()  
    { 
        LockCursor(); 
        LoadScene("HardRoom"); 
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void LockCursor()
    {
        // Hide and locks the cursor when entering a room
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
