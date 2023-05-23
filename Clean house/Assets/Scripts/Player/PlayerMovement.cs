using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController charController;
    public float speed = 6.0f;
    public float jumpForce = 15.0f;
    private float vertSpeed;
    private float gravity = -50f;

    // Start is called before the first frame update
    void Start()
    {
        vertSpeed = gravity;
        charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * speed;
        float verticalInput = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = Vector3.ClampMagnitude(movement, speed);

        if (charController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                vertSpeed = jumpForce;
            }
        }
        else
        {
            vertSpeed += gravity * Time.deltaTime;
        }

        movement.y = vertSpeed;
        movement *= Time.deltaTime;

        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
