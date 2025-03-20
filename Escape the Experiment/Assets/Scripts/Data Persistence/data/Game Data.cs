using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public Vector3 playerPosition;

    public SerializableDictionary<string, bool> cluesCollected;



    public GameData()
    {
        playerPosition =  Vector3.zero;
        cluesCollected = new SerializableDictionary<string, bool>(); 
    }
}
