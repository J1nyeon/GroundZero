using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics.Raycast(pos,Vector3.forward,out RaycastHit hit,100f))
            {
                Debug.Log(hit.collider.name);
            }
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
        else
        {
            isZoom = false;
        }
        animator.SetBool("ZoomBool", isZoom);
    }

    
   
}
