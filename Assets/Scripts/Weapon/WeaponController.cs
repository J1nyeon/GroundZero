using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //public Weapon_ weapon;

    public WeaponTest test;
    public Animator animator;
    public bool isZoom = false;

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
        if (Input.GetKey(KeyCode.Mouse1))
        {
            isZoom = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isZoom = false;
        }
        animator.SetBool("ZoomBool", isZoom);




    }
}
