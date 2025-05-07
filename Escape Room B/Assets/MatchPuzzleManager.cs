using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPuzzleManager : MonoBehaviour
{
    public static MatchPuzzleManager Instance;

    public PodiumHoldPoint[] podiums;         
    public GameObject objectToActivate;       

    private bool puzzleSolved = false;        

    void Awake()
    {
        Instance = this;
    }

    public void CheckPuzzle()
    {
        if (puzzleSolved) return;

        foreach (PodiumHoldPoint podium in podiums)
        {
            if (!podium.IsCorrect())
                return;
        }

        Debug.Log("All cubes placed correctly! Activating next object.");
        puzzleSolved = true;

        if (objectToActivate != null)
            objectToActivate.SetActive(true);
    }
}