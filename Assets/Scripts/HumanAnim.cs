using UnityEngine;

public class HumanAnim : MonoBehaviour
{
    public Animator animator;
    void Start()
    {

    }

    void Update()
    {

    }

    public void Human1PointEnter()
    {
        animator.SetInteger("Human", 1);
    }
    public void Human1PointExit()
    {
        animator.SetInteger("Human", 2);

    }

    public void Human2PointEnter()
    {
        animator.SetInteger("Human", 3);
    }
    public void Human2PointExit()
    {
        animator.SetInteger("Human", 2);

    }
}
