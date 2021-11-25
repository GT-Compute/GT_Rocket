using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force = 0.5f;
    [SerializeField] float rcsforce = 0.5f;
    [SerializeField] float fuel = 100.0f;
    [SerializeField] float RCSfuel = 100.0f;
    Vector3 forceDirect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetAxis("Thrust") > 0.3)
        {
            

            forceDirect = new Vector3(0,force * Time.deltaTime * Input.GetAxis("Thrust"),0);
            rb.AddRelativeForce(forceDirect);
            fuel -= 1f * Time.deltaTime;

        }

    }

        void ProcessRotation()
    {
        if (Input.GetAxis("Horizontal") > 0.05f || Input.GetAxis("Horizontal") < -0.05f )
        {
            forceDirect = new Vector3(0,0,(-1)*rcsforce * Time.deltaTime *Input.GetAxis("Horizontal"));
            rb.AddRelativeTorque(forceDirect);
            RCSfuel -= 1f * Time.deltaTime * Input.GetAxis("Horizontal");
        }

    }
}
