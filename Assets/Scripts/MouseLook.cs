using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    private float X;
    private float Y;
    public float Sensitivity;
 
void Start()
{
    Cursor.lockState = CursorLockMode.Locked;
    Vector3 euler = transform.rotation.eulerAngles;
    X = euler.x;
    Y = euler.y;
}
 
void Update()
{
    //configuration to player movement restrictions
    //limit in width x axis
    const float MIN_X = 0.0f;
    const float MAX_X = 360.0f;
    //limit in height y axis
    const float MIN_Y = -90.0f;
    const float MAX_Y = 90.0f;
 
    X += Input.GetAxis("Mouse X") * (Sensitivity * Time.deltaTime);
    if (X < MIN_X) X += MAX_X;
    else if (X > MAX_X) X -= MAX_X;
    Y -= Input.GetAxis("Mouse Y") * (Sensitivity * Time.deltaTime);
    if (Y < MIN_Y) Y = MIN_Y;
    else if (Y > MAX_Y) Y = MAX_Y;
 
    transform.rotation = Quaternion.Euler(Y, X, 0.0f);
}
}



// I do not know why this code do not work
// public float mouseSensitivity = 100f;
    // public Transform playerBody;
    // float xRotation = 0f;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     Cursor.lockState = CursorLockMode.Locked;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    //     float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    //     xRotation -= mouseY;
    //     xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);
        
    //     transform.localRotation = Quaternion.Euler(xRotation,  0f, 0f);
    //     playerBody.Rotate(Vector3.up * mouseX);
        


    // }