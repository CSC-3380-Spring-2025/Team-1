using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
       SceneManager.LoadScene("LevelSelect");
    }

    public void InstructGame()
    {
       SceneManager.LoadScene("Instructions"); 
    }
}
