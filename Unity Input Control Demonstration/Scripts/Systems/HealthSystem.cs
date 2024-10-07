using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    //Values
    int CurrentHealth;
    int MaxHealth; 

    //Properties
    public int Health
    {
        get
        {
            return CurrentHealth;
        }
        set
        {
            CurrentHealth = value; 
        }
    }
    public int MaxHealthM
    {
        get 
        {
            return MaxHealth; 
        }
        set
        {
            MaxHealth = value; 
        }
    }

//Class Constructor 

    public HealthSystem(int Health, int MaxHealthI)
    {
        CurrentHealth = Health;
        MaxHealth = MaxHealthI;
    }

//Property Methods
    public void DamagePlayer(int DamageAmount)
    {
        if(CurrentHealth > 0)
        {
            CurrentHealth -= DamageAmount;
        }
    }
    public void HealPlayer(int RecoverAmount)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth += RecoverAmount;
        }
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }






















    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("You have collided with the BAD CUBE!"); 
        }
    }
   
}
