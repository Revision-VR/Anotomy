using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestSceneChange : MonoBehaviour
{
    public Animator changeAnim;
    public GameObject TurnOfAnim;


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
}