using UnityEngine;
using System.Collections;

//DESFASADO

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class Movimiento : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    //public float rotationSpeed = 6.0f;
    //public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    //float angle;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 moveRotation = Vector3.zero;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;
            //moveRotation = new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f);
            //moveRotation *= rotationSpeed;

            /*
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            */


        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)


        moveDirection.y -= gravity * Time.deltaTime;


        // Move the controller

        characterController.Move(moveDirection * Time.deltaTime);
        //transform.Rotate(moveRotation * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, -Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * 180 / Mathf.PI, 0);

    }
}