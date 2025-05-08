using UnityEngine;

public class ChemistryTableInteract : MonoBehaviour, IInteractable
{
    public ChemistryPuzzle chemistryPuzzleScript;

    public void Interact()
    {
        chemistryPuzzleScript.OpenUI();
    }
}