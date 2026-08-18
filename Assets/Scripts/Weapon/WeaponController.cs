using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //public Weapon_ weapon;

    public WeaponTest test;

    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            test.Fire();
            //weapon.Fire();
        }
        //if (Input.GetKeyDown(KeyCode.R) || weapon.currentBullet <= 0)
        //{
            //weapon.Reload();
           
        //}
        if (Input.GetKeyDown(KeyCode.R) || test.bullet <= 0)
        {
            test.Reload();
        }
       
    }
}
