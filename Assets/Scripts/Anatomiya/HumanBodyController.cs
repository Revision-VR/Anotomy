using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBodyController : MonoBehaviour
{

    [SerializeField] private Animator _bodyAnimations;

    
    public void PlayAnimations(int index)
    {
        _bodyAnimations.SetInteger("HumanBody", index);
    }

}
