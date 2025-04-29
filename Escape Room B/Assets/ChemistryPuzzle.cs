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

    private List<string> correctCombination = new List<string> { "H2O", "NaCl" }; // You can change this

    public void OpenUI()
    {
        chemistryTableUI.SetActive(true);

        //unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseUI()
    {
        chemistryTableUI.SetActive(false);

        // Lock and hide the cursor again
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MixChemicals()
    {
        string chem1 = chemical1Dropdown.options[chemical1Dropdown.value].text;
        string chem2 = chemical2Dropdown.options[chemical2Dropdown.value].text;

        //put selected chemicals in a list
        List<string> selected = new List<string> { chem1, chem2 };
        selected.Sort();
        correctCombination.Sort();

        //check if selected chemicals are correct
        if (selected[0] == correctCombination[0] && selected[1] == correctCombination[1]) 
        {
            resultText.text = "Success! A new clue appears!";
            stickyNote.SetActive(true);
            chemistryTableUI.SetActive(false);

            // lock the mouse again
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            resultText.text = "Incorrect. Try again.";
        }
    }
}