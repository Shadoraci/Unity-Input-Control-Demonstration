using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocomotion : MonoBehaviour
{
    [Header("Movement")]
    public float MovementSpeed;

    public Transform Orientation;

    float HorizontalInput;
    float VerticalInput;

    Vector3 MoveDirection;

    Rigidbody RB; 

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        RB.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
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
