using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    public int Damage = 5; 

    private CubeHealth CubeMaster = new CubeHealth();
    private void Start()
    {
        Destroy(this.gameObject, 5);
    }
    void OnCollisionEnter(Collision Contact)
    {
        if(Contact != null)
        {
            Destroy(this.gameObject);
        }
    }
}
