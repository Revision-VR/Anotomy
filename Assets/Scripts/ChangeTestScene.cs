using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeTestScene : MonoBehaviour
{
    public Animator changeAnim;
    public GameObject TurnOfAnim;
    public GameObject TurnOnAnim;

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
        //TurnOfAnim.SetActive(false);

     
    }
}