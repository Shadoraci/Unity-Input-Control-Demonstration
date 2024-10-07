using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    //Just for Camera Movement 
    public float SensitivityX;
    public float SensitivityY;

    public Transform Orientation;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        
        if (this.gameObject.activeInHierarchy == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        else if (this.gameObject.activeInHierarchy == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Grabbing Mouse Input
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SensitivityX;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SensitivityY;

        yRotation += MouseX;
        xRotation -= MouseY;

        //Locking angle to where you can't look up past 90* up or down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotatate Camera and Orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
}
