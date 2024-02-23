using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HumanBodyController : MonoBehaviour
{

    [SerializeField] private Animator _bodyAnimations;

    [SerializeField] private string[] _bodyInfoName;
    [SerializeField] private string[] _bodyInfo;


    [SerializeField] private TMP_Text _bodInfoNameText;
    [SerializeField] private TMP_Text _bodInfoText;

    [SerializeField] private GameObject _bodyButtons;


    public void PlayAnimations(int index)
    {
        if (_bodyButtons.activeSelf  && index == 5)
        {
            SceneManager.LoadScene("AnatomiyaMenu");
        }

        if (index < 5)
        {
            _bodInfoNameText.text = _bodyInfoName[index - 1];
            _bodInfoText.text = _bodyInfo[index - 1];
            _bodyButtons.SetActive(false);
        }
        else
        {
            _bodyButtons.SetActive(true);
        }
        


        _bodyAnimations.SetInteger("HumanBody", index);
    }

}
