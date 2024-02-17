using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject[] RegisterObjects;
    public GameObject[] JinsObjects;
    public Text ErrorIsm;
    public Text ErrorFamilya;

    [SerializeField]
    private GameObject[] _errorTexts;

    void Update()
    {
    }

    private void OnOf()
    {
        foreach (GameObject obj in RegisterObjects)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in JinsObjects)
        {
            obj.SetActive(true);
        }
    }

    public void Enter()
    {

        foreach (GameObject obj in _errorTexts)
        {
            obj.SetActive(false);
        }


        if (string.IsNullOrEmpty(ErrorIsm.text))
            _errorTexts[0].SetActive(true);

        if (string.IsNullOrEmpty(ErrorFamilya.text))
            _errorTexts[1].SetActive(true);

        if (string.IsNullOrEmpty(ErrorIsm.text) || string.IsNullOrEmpty(ErrorFamilya.text))
            return; 

        OnOf();
    }
}
