using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    public Dropdown dropdown;

    private string dropdownPrefsKey = "DropdownValue";

    void Start()
    {
        // Load the previously saved dropdown value
        int savedValue = PlayerPrefs.GetInt(dropdownPrefsKey, 0); // Default to 0 if no value is found
        dropdown.value = savedValue;
    }

    public void OnDropdownValueChanged()
    {
        // Save the current dropdown value
        PlayerPrefs.SetInt(dropdownPrefsKey, dropdown.value);
        PlayerPrefs.Save(); // Make sure to save changes
    }
}
