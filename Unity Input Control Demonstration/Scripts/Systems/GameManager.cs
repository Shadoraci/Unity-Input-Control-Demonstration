using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerUI; 
    public GameObject MenuUI;
    public GameObject Player; 
    public static GameManager Director {  get; private set; }

    public HealthSystem PlayerHealth = new HealthSystem(100, 100);

    // Start is called before the first frame update
    void Awake()
    {
        //Checking to make sure this is the only GameManager
      if(Director != null && Director != this)
        {
            Destroy(this);
        }
        else
        {
            Director = this; 
        }
    }
    public void SwitchScripts() 
    {
        MenuUI.SetActive(true);
        PlayerUI.SetActive(false);
    }
    public void SwitchBackScripts() //switches GUIs
    {
        MenuUI.SetActive(false);
        PlayerUI.SetActive(true);
    }
    public void SwitchingControlsProfile1()
    {
        Player.GetComponent<CameraController>().enabled = true;
        Player.GetComponent<CameraLocomotion>().enabled = true;

        Player.GetComponent<Movement>().enabled = false;
        Player.GetComponent<Control3>().enabled = false;

    }
    public void SwitchingControlsProfile2()
    {
        Player.GetComponent<CameraController>().enabled = false;
        Player.GetComponent<CameraLocomotion>().enabled = false;

        Player.GetComponent<Movement>().enabled = true;
        Player.GetComponent<Control3>().enabled = false;
    }
    public void SwitchingControlsProfile3()
    {
        Player.GetComponent<CameraController>().enabled = false;
        Player.GetComponent<CameraLocomotion>().enabled = false;

        Player.GetComponent<Movement>().enabled = false;
        Player.GetComponent<Control3>().enabled = true;
    }
}
