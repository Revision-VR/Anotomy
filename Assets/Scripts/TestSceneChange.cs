using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestSceneChange : MonoBehaviour
{
    public Animator changeAnim;
    public GameObject TurnOfAnim;
    public GameObject TurnOnAnim;

    public void Start()
    {
        StartCoroutine(AnimationController1());
    }


    public void Click()
    {
        StartCoroutine(AnimationController());
        
    }

    private IEnumerator AnimationController()
    {
        TurnOfAnim.SetActive(true);
        changeAnim.Play("CanvasAnim");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4);
    }

    public IEnumerator AnimationController1()
    {
        TurnOnAnim.SetActive(true);
        changeAnim.Play("TurnOnAnim");
        yield return new WaitForSeconds(1f);
    }
}