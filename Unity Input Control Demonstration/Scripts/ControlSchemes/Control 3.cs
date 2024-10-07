using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Control3 : MonoBehaviour
{
    [Header("LookingAround")]

    public float SensitivityX;
    public float SensitivityY;

    float xRotation;
    float yRotation;

    [Header("Movement")]
    public float MovementSpeed;

    public Transform Orientation;

    float HorizontalInput;
    float VerticalInput;

    Vector3 MoveDirection;

    Rigidbody RB;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.freezeRotation = true;
    }
    void Update()
    {
        //Grabbing Mouse Input
        float MouseX = Input.GetAxisRaw("Xbox One Axis X") * Time.deltaTime * SensitivityX;
        float MouseY = Input.GetAxisRaw("Xbox One Axis Y") * Time.deltaTime * SensitivityY;

        yRotation += MouseX;
        xRotation -= MouseY;

        //Locking angle to where you can't look up past 90* up or down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotatate Camera and Orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        MyInput();

       
       
    }
    private void FixedUpdate()
    {
        MovePlayer(); 
    }
    private void MyInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");

    }
    private void MovePlayer()
    {
        //calculate movement direction wee woo wee woo

        //Default---------------------------------------------------------------------
        MoveDirection = Orientation.forward * VerticalInput + Orientation.right * HorizontalInput;
        RB.AddForce(MoveDirection.normalized * MovementSpeed * 10f, ForceMode.Force);
    }

}
