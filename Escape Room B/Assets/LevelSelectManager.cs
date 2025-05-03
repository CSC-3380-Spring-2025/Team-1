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
        
        easyButton.interactable = true;
        medButton.interactable = PlayerPrefs.GetInt("EasyRoomCompleted", 0) == 1;
        hardButton.interactable = PlayerPrefs.GetInt("MedRoomCompleted", 0) == 1;
    }

    public void LoadEasyRoom()  { LoadScene("EasyRoom"); }
    public void LoadMedRoom()   { LoadScene("MedRoom"); }
    public void LoadHardRoom()  { LoadScene("HardRoom"); }


    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
