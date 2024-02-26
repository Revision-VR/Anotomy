using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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


    [SerializeField]
    private string[] _infoes;

    [SerializeField]
    private string[] _infoesNames;


    [SerializeField]
    private TMP_Text _infoName;

    [SerializeField]
    private TMP_Text _infoText;


    [SerializeField]
    private GameObject[] _indidualObjects;


    [SerializeField]
    private GameObject HumanParentModel;

    private Transform dragging;
    private Vector3 offset;



    private bool doubleClick = true;
    private bool canRotate;



    int rotationY = 0;


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

                ShowInfo(hit.transform.GetSiblingIndex());
                
                if (doubleClick)
                {
                    Invoke(nameof(StopDoubleClick), 0.3f);
                    doubleClick = false;
                    return;
                }
                doubleClick = true;

                DoubleClicked(hit.transform.GetSiblingIndex());
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

        ShowInfo(index);

        if (doubleClick)
        {
            Invoke(nameof(StopDoubleClick), 0.3f);
            doubleClick = false;

            if (HumanParentModel.activeSelf)
            {
                return;
            }

        }
        doubleClick = true;

        DoubleClicked(index);
    }


    public void OrganMaterialsByDefoult()
    {
        for (int i = 0; i < _organs.Length; i++)
        {
            _organs[i].GetComponent<MeshRenderer>().material = _organMaterials[i];
        }
    }

    public void ResetButton()
    {
        rotationY = 0;
        OrganMaterialsByDefoult();
        _humanModel.transform.rotation = Quaternion.identity;
        for (int i = 0; i < _organs.Length; i++)
        {
            _organs[i].transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }


    public void RotateNinetyGradus(bool isPlus)
    {
        if (isPlus)
        {
            _humanModel.transform.rotation = Quaternion.Euler(0f, rotationY += 90, 0f);
        }
        else
        {
            _humanModel.transform.rotation = Quaternion.Euler(0f, rotationY -= 90, 0f);
        }
    }



    public void BackButton()
    {
        if (HumanParentModel.activeSelf)
        {
            SceneManager.LoadScene(1);
            return;
        }

        DisableIndividualOrgans();
        HumanParentModel.SetActive(true);

    }



    void ShowInfo(int index)
    {
        _infoName.text = _infoesNames[index];
        //_infoText.text = _infoes[index];
    }


    void DoubleClicked(int index)
    {
        print("double click");
        ResetButton();


        HumanParentModel.SetActive(false);
        DisableIndividualOrgans();

        _indidualObjects[index].SetActive(true);
        _humanModel = _indidualObjects[index].transform.parent.gameObject;

    }

    void DisableIndividualOrgans()
    {
        for (int i = 0; i < _indidualObjects.Length; i++)
        {
            _indidualObjects[i].SetActive(false);
        }
    }

}
