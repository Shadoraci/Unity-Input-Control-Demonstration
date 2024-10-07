using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHealth : MonoBehaviour
{
    private int CubeMaxHealth { get; set; }
    public GameObject HealthbarBox; 

    private void Start()
    {
        CubeMaxHealth = 100; 
    }
    void Update()
    {
        if(CubeMaxHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("CUBE WAS DESTROYYYYYYYYYYYYYED!!!");
        }
    }
    public void DamageCube(int dmgamount)
    {
        CubeMaxHealth -= dmgamount;
        HealthbarBox.transform.localScale = new Vector3(.01f * CubeMaxHealth,.2f , 1); 
        Debug.Log("CUBE WAS HIT!!! It has " + CubeMaxHealth + "Health left. DamageAmount: + " + dmgamount);
    }
    private void OnCollisionEnter(Collision Contact)
    {
        if(Contact.gameObject.tag == "Bullet")
        {
            DamageCube(Contact.gameObject.GetComponent<BulletPhysics>().Damage);

        }
    }
}
