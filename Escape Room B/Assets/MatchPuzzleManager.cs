using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPuzzleManager : MonoBehaviour
{
    public static MatchPuzzleManager Instance; // singleton so we can call this from other scripts

    public PodiumHoldPoint[] podiums;         // all the podiums we need to check
    public GameObject objectToActivate;       // object that shows up when puzzle is solved (like a keypad)

    private bool puzzleSolved = false;        // stop it from running twice

    void Awake()
    {
        Instance = this;
    }

    public void CheckPuzzle()
    {
        if (puzzleSolved) return; // already solved

        foreach (PodiumHoldPoint podium in podiums)
        {
            if (!podium.IsCorrect())
                return; // if one podium is wrong, stop checking
        }

        Debug.Log("All cubes placed correctly! Activating next object.");
        puzzleSolved = true;

        if (objectToActivate != null)
            objectToActivate.SetActive(true); // show the object
    }
}