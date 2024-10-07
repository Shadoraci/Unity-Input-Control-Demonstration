using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerBehavior : MonoBehaviour
{
    public TMP_Text HealthText; 
    [SerializeField] HealthbarScript Healthbar;

    private float Timer = 0f;

    [Header("Bullets")]

    public GameObject[] BulletArray = new GameObject[2];
    public Transform ShotSpawn;
    private GameObject NewBullet;
    public int ShootForce = 0; 

    void Update()
    {
        Timer += Time.deltaTime; 

        if (Timer > 10f) //10 second timer here
        {
            HealDamage(2);
            Timer = 0f;
            Debug.Log("I healed! I now have " + GameManager.Director.PlayerHealth.Health);
        }

        HealthText.text = GameManager.Director.PlayerHealth.Health.ToString();

        if (GameManager.Director.PlayerHealth.Health <= 0)
        {
            //this.gameObject.transform.position = new Vector3(-7.657594f, 2.659522f, -20.63198f);
            GameManager.Director.PlayerHealth.HealPlayer(100);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Shoot();
            Debug.Log("I am firing!");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           Shoot();
            Debug.Log("I am firing!");
        }
    }
    private void TakeDamage(int DamageAmount)
    {
        GameManager.Director.PlayerHealth.DamagePlayer(DamageAmount);
        Debug.Log("Ouch! I now have " + GameManager.Director.PlayerHealth.Health);
        Healthbar.SetHealth(GameManager.Director.PlayerHealth.Health);
    }
    private void HealDamage(int HealAmount)
    {
        GameManager.Director.PlayerHealth.HealPlayer(HealAmount);
        Healthbar.SetHealth(GameManager.Director.PlayerHealth.Health);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(5);
            Timer = 0f; 
        }
    }
    private void Shoot()
    {
       int RandomBullet = Random.Range(0,2);
       NewBullet = BulletArray[RandomBullet];
       GameObject FiredBullet = Instantiate(NewBullet, ShotSpawn.position, ShotSpawn.rotation);
       FiredBullet.GetComponent<Rigidbody>().velocity = transform.forward * ShootForce;
    }
}
