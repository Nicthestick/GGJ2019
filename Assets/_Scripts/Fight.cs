using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public bool Attack = false;

    private void Update()
    {
        // Get a copy of your forward vector
        Vector3 forward = transform.forward;
        // Zero out the y component of your forward vector to only get the direction in the X,Z plane
        forward.y = 0;
        float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;

        if(Input.GetAxis("Fire1") != 0)
        {

            Attack = true;

            Debug.Log(Attack);

        }
        else
        {
            Attack = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log(Attack + " player");
        }
    }



}
