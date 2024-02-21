using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHumanModel : MonoBehaviour
{


    [SerializeField]
    private float RotationSpeed;

    [SerializeField]
    private GameObject _humanModel;

    [SerializeField]
    private GameObject[] _organs;

    [SerializeField]
    private Material _selectedMaterial;

    [SerializeField]
    private Material[] _organMaterials;

    private Transform dragging;
    private Vector3 offset;



    private bool doubleClick = true;
    private bool canRotate;




    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                OrganMaterialsByDefoult();
                hit.transform.gameObject.GetComponent<MeshRenderer>().material = _selectedMaterial;
                dragging = hit.transform;
                offset = Input.mousePosition - Camera.main.WorldToScreenPoint(dragging.position);

                if (doubleClick)
                {
                    Invoke(nameof(StopDoubleClick), 0.3f);
                    doubleClick = false;
                    return;
                }
                doubleClick = true;

                print("Double Click");

            }
            else
            {
                canRotate = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            canRotate = false;
            dragging = null;
        }

        if (canRotate)
        {
            _humanModel.transform.Rotate(Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime, -(Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0);
        }

        if (dragging != null)
        {
            dragging.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - offset);
        }

    }

    void StopDoubleClick()
    {
        doubleClick = true;
    }



    public void OrganButtons(int index)
    {
        OrganMaterialsByDefoult();
        _organs[index].GetComponent<MeshRenderer>().material = _selectedMaterial;

        if (doubleClick)
        {
            Invoke(nameof(StopDoubleClick), 0.3f);
            doubleClick = false;
            return;
        }
        doubleClick = true;


    }


    public void OrganMaterialsByDefoult()
    {
        for (int i = 0; i < _organs.Length; i++)
        {
            _organs[i].GetComponent<MeshRenderer>().material = _organMaterials[i];
        }
    }


    void DoubleClicked(int index)
    {
        print("double click");

    }

}
