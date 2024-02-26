using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    //public Dropdown dropdown;
    public TMP_Dropdown TMP_Dropdown;

    private string dropdownPrefsKey = "DropdownValue";

    void Start()
    {
        int savedValue = PlayerPrefs.GetInt(dropdownPrefsKey, 0); // Default to 0 if no value is found
        TMP_Dropdown.value = savedValue;
    }

    public void OnDropdownValueChanged()
    {
        PlayerPrefs.SetInt(dropdownPrefsKey, TMP_Dropdown.value);
        PlayerPrefs.Save(); // Make sure to save changes
    }
}
