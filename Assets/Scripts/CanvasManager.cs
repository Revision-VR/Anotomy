using System.Collections;
using System.Runtime.CompilerServices;
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
    public GameObject TurnOfAnim;
    public GameObject TurnOnAnim;
    public Animator CanvasAnim;
    public Animator CanvasAnim1;
    public Text ErrorIsm;
    public Text ErrorFamilya;
    [SerializeField] private GameObject[] _errorTexts;


    public void Start()
    {
        StartCoroutine(Wait());
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Enter();
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

        foreach (GameObject obj in RegisterObjects)
        {
            obj.SetActive(false);
        }


        StartCoroutine(AnimationController());
    }


    private IEnumerator AnimationController()
    {
        TurnOfAnim.SetActive(true);
        CanvasAnim.Play("CanvasAnim");
        yield return new WaitForSeconds(1f);
        TurnOfAnim.SetActive(false);
        StartCoroutine(AnimationController1());
        foreach (GameObject obj in JinsObjects)
        {
            obj.SetActive(true);
        }
    }

    private IEnumerator AnimationController1()
    {
        TurnOnAnim.SetActive(true);
        CanvasAnim.Play("TurnOnAnim");
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator AnimationController2()
    {
        TurnOfAnim.SetActive(true);
        CanvasAnim.Play("CanvasAnim");
        yield return new WaitForSeconds(1f);
        TurnOfAnim.SetActive(false);

        StartCoroutine(AnimationController1());

        foreach (GameObject obj in FanlarObjects)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in TextObjects)
        {
            obj.SetActive(true);
        }
    }
    public void OnOf1()
    {
        StartCoroutine(AnimationController2());
        foreach (GameObject obj in JinsObjects)
        {
            obj.SetActive(false);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(11);
        videoController.SetActive(false);
        CanvasAnim.Play("TurnOnAnim");
    }
}
