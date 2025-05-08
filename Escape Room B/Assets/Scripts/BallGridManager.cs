using System;
using System.Collections.Generic;
using UnityEngine;

public class BallGridManager : MonoBehaviour
{
    public static BallGridManager Instance { get; private set; }
    //This will allow us to drag each ballbutton object into one of the 12 fields
    public BallButton[] balls = new BallButton[12];
    //tells us which are correct
    public int[] correctIndices = new int[8];
    //keeps track of active balls already pressed
    HashSet<int> _activated = new HashSet<int>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void HandleBallClick(int index, BallButton btn)
    {
        //doesnt allow you to do anything to already active buttons
        if (_activated.Contains(index)) return;
        if (Array.IndexOf(correctIndices, index) < 0) return;

        //Marks the button as active
        btn.Activate();
        _activated.Add(index);

        if (_activated.Count == correctIndices.Length)
            OnAllCorrect();
    }
    //if all the buttons clicked are right, this should print in the console
    void OnAllCorrect()
    {
        Debug.Log("All 8 balls activated! Clue = 8");
        
    }
}
