using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    //Variables
    [HideInInspector]
    public float speed = 20F;
    public float jumpSpeed = 15f;
    public float gravity = 20.0F;
    public float thrust;
    public Rigidbody rb;


    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpSpeed = 15f;
        speed = 30f;
    }

    public Vector3 Playerfwd;
    public float headingAngle;
    Vector3 forward;

    public bool Attack = false;


    void Update()
    {
        // Get a copy of your forward vector
        forward = transform.forward;
        // Zero out the y component of your forward vector to only get the direction in the X,Z plane
        forward.y = 0;
        headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;

        // Get a copy of your forward vector
        Playerfwd = transform.forward;
        // Zero out the y component of your forward vector to only get the direction in the X,Z plane
        Playerfwd.y = 0;
        headingAngle = Quaternion.LookRotation(Playerfwd).eulerAngles.y;

        if (!isLocalPlayer)
        {
            return;
        }

        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?

        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            transform.Rotate(0, Input.GetAxis("Mouse X") * 100 * Time.deltaTime, 0);

            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }

        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);

    }
    
    public override void OnStartLocalPlayer()
    {
        foreach (MeshRenderer variableName in GetComponentsInChildren<MeshRenderer>())
        {
            variableName.material.color = Color.green;
        }

    }
}