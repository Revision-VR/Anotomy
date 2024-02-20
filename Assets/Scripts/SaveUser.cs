using UnityEngine;
using UnityEngine.UI;

public class SaveUser : MonoBehaviour
{
    public Text Ism;
    public Text Familya;
    public Text scaledNameText;

    private string name;
    private string surname;

    void Start()
    {
        // You can call the method to save the user's name and surname here or elsewhere in your code.

        // Call the method to scale and display the name on UI.
        //DisplayScaledName();
    }

    void Update()
    {
        SaveUserData();

        // You can add update logic here if needed.
    }

    void SaveUserData()
    {
        // Retrieve the name and surname from the Text components and store them in variables.
        name = Ism.text;
        surname = Familya.text;

        // You can use PlayerPrefs or another method to save the user's data.
        PlayerPrefs.SetString("Name", name);
        PlayerPrefs.SetString("Surname", surname);

        // Optionally, you can print the saved data for debugging purposes.
        Debug.Log("User's name: " + name);
        Debug.Log("User's surname: " + surname);
    }

    public void DisplayScaledName()
    {
        // Here you can scale the name as desired.
        string scaledName = ScaleName(name);

        // Assign the scaled name to the UI Text component.
        scaledNameText.text = scaledName;
    }

    string ScaleName(string originalName)
    {
        // Example of scaling the name (just appending " - Scaled" for demonstration).
        return originalName + " - Scaled";
    }
}
