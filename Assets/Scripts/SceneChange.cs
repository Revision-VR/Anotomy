using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Animator animator;
    public GameObject Button1;
    public GameObject Button2;
   

    public void SceneAlmashuv()
    {
        //animator.Play("HumanSceneAlmashuv");
        animator.SetInteger("Human", 5);
        Button1.SetActive(false);
        Button2.SetActive(false);
        StartCoroutine(kutish());
      
    }
    public void SceneAlmashuv1()
    {
        animator.SetInteger("Human", 5);
        Button1.SetActive(false);
        Button2.SetActive(false);
        StartCoroutine(kutish1());

    }

    IEnumerator kutish()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
    IEnumerator kutish1()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);
    }
}
