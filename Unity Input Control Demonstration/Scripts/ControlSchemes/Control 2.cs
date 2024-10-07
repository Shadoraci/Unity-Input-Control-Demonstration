using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    public float MovementSpeed = 10;

    private void Start()
    {
        this.gameObject.transform.rotation = Quaternion.identity;
    }
    void Update()
    {
        //MOVING AROUND
        if (Input.GetKey(KeyCode.T))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * MovementSpeed);
            //RB.AddForce(Vector3.forward * MovementSpeed); 
        }
        if (Input.GetKey(KeyCode.G))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * MovementSpeed);
            //RB.AddForce(Vector3.back * MovementSpeed);
        }
        if (Input.GetKey(KeyCode.F))
        {
             this.transform.Translate(Vector3.left * Time.deltaTime * MovementSpeed);
            //RB.AddForce(Vector3.left * MovementSpeed);
        }
        if (Input.GetKey(KeyCode.H))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * MovementSpeed);
            //RB.AddForce(Vector3.right * MovementSpeed);
        }



        //LOOKING AROUND
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.up, -5);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up, 5);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Rotate(Vector3.right, 5);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Rotate(Vector3.right, -5);
        }

        //Optional looking 
        /* if (Input.GetKey(KeyCode.UpArrow))
         {
             this.transform.Rotate(Vector3.left, -10);
         }
         if (Input.GetKey(KeyCode.DownArrow))
         {
             this.transform.Rotate(Vector3.left, 10);
         }
        */
    }
}