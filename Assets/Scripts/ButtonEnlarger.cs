using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEnlarger : MonoBehaviour
{
    public Button button; 
    public float rotationSpeed = 5f; 
    private Quaternion originalRotation;
    private bool isMouseOver = false;

    void Start()
    {
        originalRotation = button.transform.rotation;
    }

    void Update()
    {
        if (isMouseOver)
        {
            button.transform.rotation = Quaternion.RotateTowards(button.transform.rotation, Quaternion.identity, rotationSpeed * Time.deltaTime);
        }
        else
        {
            button.transform.rotation = Quaternion.RotateTowards(button.transform.rotation, originalRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void OnPointerEnter()
    {
        StopCoroutine("ResetRotation");
        isMouseOver = true;
    }

    public void OnPointerExit()
    {
        StartCoroutine("ResetRotation");
    }

    IEnumerator ResetRotation()
    {
        yield return new WaitForSeconds(0.1f); // Delay for better UX
        isMouseOver = false;
    }
}
