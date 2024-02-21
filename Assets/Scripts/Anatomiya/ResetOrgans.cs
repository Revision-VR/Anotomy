using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOrgans : MonoBehaviour
{


    [SerializeField]
    private Vector3 resetPos;


    [SerializeField]
    private GameObject _pos;

    bool inSide = false;


    private void OnTriggerEnter(Collider other)
    {
        _pos.SetActive(true);
        inSide = true;
    }



    private void OnTriggerExit(Collider other)
    {
        _pos.SetActive(false);
        inSide = false;
    }



    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0) && inSide)
        {
            transform.localPosition = resetPos;
        }

        if (transform.localPosition == resetPos)
        {
            _pos.SetActive(false);
        }
    }
}
