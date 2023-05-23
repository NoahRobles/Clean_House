using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HorizontalMouseLook : MonoBehaviour { 
public float mouseXSensitivity = 9.0f;

private Rigidbody body;
private void Start()
{
    body = GetComponent<Rigidbody>();
    if (body != null)
    {
        body.freezeRotation = true;
    }
}
// Update is called once per frame
void Update()
{
    transform.Rotate(0, Input.GetAxis("Mouse X") * mouseXSensitivity, 0);
}
}