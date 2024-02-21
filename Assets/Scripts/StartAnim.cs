using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnim : MonoBehaviour
{
    public Animator humanAnimator;
    void Start()
    {
        humanAnimator.Play("HumanSceneKirish");
    }

}
