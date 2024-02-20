using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CanvasManager : MonoBehaviour
{
    public GameObject[] RegisterObjects;
    public GameObject[] JinsObjects;
    public GameObject[] FanlarObjects;
    public GameObject[] TextObjects;
    public GameObject videoController;
    public GameObject videoController1;
    public Text ErrorIsm;
    public Text ErrorFamilya;
    [SerializeField] private GameObject[] _errorTexts;

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

        foreach (GameObject obj in RegisterObjects)
        {
            obj.SetActive(false);
        }

        StartCoroutine(PlayVideoAndSwitchObjects());
    }

    private IEnumerator PlayVideoAndSwitchObjects()
    {
        videoController.SetActive(true);
        yield return StartCoroutine(WaitAndExecute());
        videoController.SetActive(false);

        foreach (GameObject obj in JinsObjects)
        {
            obj.SetActive(true);
        }
    }

    private IEnumerator WaitAndExecute()
    {
        yield return new WaitForSeconds(7f);
    }

    public void OnOf1()
    {
        foreach (GameObject obj in JinsObjects)
        {
            obj.SetActive(false);
        }

        StartCoroutine(PlayVideoAndSwitchObjects1());
    }
    private IEnumerator PlayVideoAndSwitchObjects1()
    {
        videoController1.SetActive(true);
        yield return StartCoroutine(WaitAndExecute1());
        videoController1.SetActive(false);

        foreach (GameObject obj in FanlarObjects)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in TextObjects)
        {
            obj.SetActive(true);
        }
    }

    private IEnumerator WaitAndExecute1()
    {
        yield return new WaitForSeconds(4f);
    }

}
