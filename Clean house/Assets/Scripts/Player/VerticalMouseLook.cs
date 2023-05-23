using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMouseLook : MonoBehaviour
{
    public float mouseYSensitivity = 9.0f;

    // Prevent player from looking too high or too low
    private float constrainVert = 45.0f;
    private float vertRotation = 0.0f;

    // Update is called once per frame
    void Update()
    {
        vertRotation -= Input.GetAxis("Mouse Y") * mouseYSensitivity;
        vertRotation = Mathf.Clamp(vertRotation, -constrainVert, constrainVert);

        // Prevent the vertical mouse rotation from altering the horizontal roation
        // In a sense preserve the last instance of horizontal rotation.
        float horizontalRotation = transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(vertRotation, horizontalRotation, 0);
    }
}