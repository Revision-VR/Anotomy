using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubjectsManag : MonoBehaviour
{
    public Rigidbody[] rigidbodies;
    
    public void Click()
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.useGravity = true;
        }

        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("AnatomiyaMenu");
    }

}
