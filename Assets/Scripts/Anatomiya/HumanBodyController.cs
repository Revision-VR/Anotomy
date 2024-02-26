using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanBodyController : MonoBehaviour
{

    [SerializeField] private Animator _bodyAnimations;

    [SerializeField] private string[] _bodyInfoName;
    [SerializeField] private string[] _bodyInfoNameRu;
    [SerializeField] private string[] _bodyInfoNameEn;

    [SerializeField] private string[] _bodyInfo;
    [SerializeField] private string[] _bodyInfoRu;
    [SerializeField] private string[] _bodyInfoEn;



    [SerializeField] private TMP_Text _bodInfoNameText;
    [SerializeField] private TMP_Text _bodInfoText;

    [SerializeField] private GameObject _bodyButtons;

    string _language;

    private void Start()
    {
        _language = PlayerPrefs.GetString("Language");
    }

    public void PlayAnimations(int index)
    {
        if (_bodyButtons.activeSelf  && index == 5)
        {
            SceneManager.LoadScene("AnatomiyaMenu");
        }

        if (index < 5)
        {

            switch (_language)
            {
                case "uz":
                    _bodInfoNameText.text = _bodyInfoName[index - 1];
                    _bodInfoText.text = _bodyInfo[index - 1];
                    print(1);
                    _bodyButtons.SetActive(false);
                    break;

                case "ru":
                    _bodInfoNameText.text = _bodyInfoNameRu[index - 1];
                    _bodInfoText.text = _bodyInfoRu[index - 1];
                    print(1);

                    _bodyButtons.SetActive(false);
                    break;

                case "en":
                    _bodInfoNameText.text = _bodyInfoNameEn[index - 1];
                    _bodInfoText.text = _bodyInfoEn[index - 1];
                    print(1);

                    _bodyButtons.SetActive(false);
                    break;
            }
            
        }
        else
        {
            _bodyButtons.SetActive(true);
        }

        _bodyAnimations.SetInteger("HumanBody", index);
    }

}
