using UnityEngine;

public class ButtonEnlarger : MonoBehaviour
{
    public GameObject Fizika;
    public GameObject Matematika;
    public GameObject Kimyo;
    public GameObject Tarix;
    public GameObject Anatomiya;
    public GameObject Astronomiya;

    //public Animator FizikaAnim;

    private Quaternion[] originalRotations;

    void Start()
    {
        // Initialize the array to store original rotations
        originalRotations = new Quaternion[]
        {
            Fizika.transform.rotation,
            Matematika.transform.rotation,
            Kimyo.transform.rotation,
            Tarix.transform.rotation,
            Anatomiya.transform.rotation,
            Astronomiya.transform.rotation
        };
    }

    // Fizika
    public void OnEnter()
    {
        //Quaternion originalRotation = Fizika.transform.rotation;

        //Fizika.transform.rotation = Quaternion.Euler(0, 0, 0);

        //FizikaAnim.SetInteger("Fizika", 1);
    }

    public void OnExit()
    {
        Fizika.transform.rotation = originalRotations[0];
        // FizikaAnim.SetInteger("Fizika", 2);
    }



    //Matematika
    public void OnEnterM()
    {
        Quaternion originalRotation = Matematika.transform.rotation;

        Matematika.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnExitM()
    {
        Matematika.transform.rotation = originalRotations[1];
    }
    //Kimyo

    public void OnEnterK()
    {
        Quaternion originalRotation = Kimyo.transform.rotation;

        Kimyo.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnExitK()
    {
        Kimyo.transform.rotation = originalRotations[2];
    }

    //Tarix

    public void OnEnterT()
    {
        Quaternion originalRotation = Tarix.transform.rotation;

        Tarix.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnExitT()
    {
        Tarix.transform.rotation = originalRotations[3];
    }

    //Anatomiya

    public void OnEnterAn()
    {
        Quaternion originalRotation = Anatomiya.transform.rotation;

        Anatomiya.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnExitAn()
    {
        Anatomiya.transform.rotation = originalRotations[4];
    }
    //Astronomiya
    public void OnEnterAs()
    {
        Quaternion originalRotation = Astronomiya.transform.rotation;

        Astronomiya.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnExitAs()
    {
        Astronomiya.transform.rotation = originalRotations[5];
    }
}
