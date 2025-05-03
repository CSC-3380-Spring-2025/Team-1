using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MatchPuzzleManager : MonoBehaviour
{public static MatchPuzzleManager Instance;

    public PodiumHoldPoint[] podiums; 
    public GameObject keypadHintUI;  
    public TMPro.TextMeshProUGUI codeText; 
    public string codeToShow = "3452"; 

    void Awake()
    {
        Instance = this;
    }

    public void CheckPuzzle()
    {
        foreach (PodiumHoldPoint podium in podiums)
        {
            if (!podium.IsCorrect())
                return; 
        }

        Debug.Log("Puzzle Solved!");
        
        if (keypadHintUI != null)
        {
            keypadHintUI.SetActive(true);

            if (codeText != null)
                codeText.text = "CODE: " + codeToShow;
        }
    }
}
