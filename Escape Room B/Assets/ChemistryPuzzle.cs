using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ChemistryPuzzle : MonoBehaviour
{
    public TMP_Dropdown chemical1Dropdown;
    public TMP_Dropdown chemical2Dropdown;
    public TMP_Text resultText;
    public GameObject chemistryTableUI;
    public GameObject stickyNote;
    public PlayerController playerController;

    private List<string> correctCombination = new List<string> { "H2O", "NaCl" }; // Player has the ability to change options. Correct answer is H2O and NaCl

    public void OpenUI()
    {
        chemistryTableUI.SetActive(true);

        // Unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Stops player movement
        if (playerController != null)
        playerController.enabled = false;
    }

    public void CloseUI()
    {
        chemistryTableUI.SetActive(false);

        // Lock and hide the cursor again
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Player can move again
        if (playerController != null)
        playerController.enabled = true;
    }

    public void MixChemicals()
    {
        string chem1 = chemical1Dropdown.options[chemical1Dropdown.value].text;
        string chem2 = chemical2Dropdown.options[chemical2Dropdown.value].text;

        // Put selected chemicals in a list
        List<string> selected = new List<string> { chem1, chem2 };
        selected.Sort();
        correctCombination.Sort();

        // Check if the selected chemicals are correct
        if (selected[0] == correctCombination[0] && selected[1] == correctCombination[1]) 
        {
            resultText.text = "Success! A new clue appears!";
            stickyNote.SetActive(true);
            CloseUI();
        }
        else
        {
            resultText.text = "Incorrect. Try again.";
        }
    }
}