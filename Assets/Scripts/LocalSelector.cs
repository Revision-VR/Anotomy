using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalSelector : MonoBehaviour
{
    private bool active = false;



    public void ChangeLocale(int localeID)
    {
        if (active)
            return;
        StartCoroutine(SetLocale(localeID));

        if (localeID == 0)
        {
            PlayerPrefs.SetString("Language", "en");
        }
        else if (localeID == 1)
        {
            PlayerPrefs.SetString("Language", "ru");

        }
        else if (localeID == 2)
        {
            PlayerPrefs.SetString("Language", "uz");
        }

    }


    IEnumerator SetLocale(int _localID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localID];
        active = false;
    }
}
