using System;
using System.Collections.Generic;
using UnityEngine;

public class BallGridManager : MonoBehaviour
{
    public static BallGridManager Instance { get; private set; }

    [Tooltip("Drag in your 12 BallButton components here, in any order")]
    public BallButton[] balls = new BallButton[12];

    [Tooltip("Which indices (0–11) are the correct ones? Exactly 8.")]
    public int[] correctIndices = new int[8];

    HashSet<int> _activated = new HashSet<int>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void HandleBallClick(int index, BallButton btn)
    {
        // If already activated or not a correct index, ignore
        if (_activated.Contains(index)) return;
        if (Array.IndexOf(correctIndices, index) < 0) return;

        // It's a correct ball—activate it
        btn.Activate();
        _activated.Add(index);

        if (_activated.Count == correctIndices.Length)
            OnAllCorrect();
    }

    void OnAllCorrect()
    {
        Debug.Log("All 8 balls activated! Clue = 8");
        // TODO: trigger your next event (e.g. enable keypad).
    }
}
